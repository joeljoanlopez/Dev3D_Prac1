using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float acceleration = 5f;
    public float maxSpeed = 10f;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    private bool jumping = false;
    private Vector3 jumpVelocity = Vector3.zero;

    [Header("Camera Settings")]
    public Transform pitchController;
    public float cameraSensitivity = 1f;
    public float maxPitch = 90f;
    public float minPitch = -90f;

    private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity = Vector3.zero;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();

        horizontalRotation = transform.eulerAngles.y;
        verticalRotation = pitchController.transform.eulerAngles.x;
    }

    /// Reads the input for movement and stores it in moveInput
    public void OnMove()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
    }

    /// Reads the input for jumping and applies an upward force
    public void OnJump()
    {
        jumping = true;
    }

    public void OnLook()
    {
        lookInput = playerInput.actions["Look"].ReadValue<Vector2>();
    }

    private void Update()
    {
        HandleMovement();
        // HandleJump();
        HandleCamera();
    }

    private void HandleMovement(){
        Vector3 targetVelocity = new Vector3(moveInput.x, 0f, moveInput.y) * maxSpeed;
        velocity = Vector3.Lerp(velocity, targetVelocity, acceleration * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);
    }

    private void HandleJump(){
        if (jumping)
        {
            Vector3 jumpTargetVelocity = Vector3.up * jumpForce;
            jumpVelocity = Vector3.Lerp(jumpVelocity, jumpTargetVelocity, acceleration * Time.deltaTime);
            characterController.Move(jumpVelocity * Time.deltaTime);
            jumping = jumpVelocity.y != 0f;
        }
        else
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }

    private void  HandleCamera(){
        horizontalRotation += lookInput.x * cameraSensitivity * Time.deltaTime;
        verticalRotation -= lookInput.y * cameraSensitivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        pitchController.transform.rotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}