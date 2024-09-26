using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    public float acceleration = 5f;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;

    private PlayerInput playerInput;
    private Rigidbody rigidBody;

    private Vector2 moveInput;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
    }

    /// Reads the input for movement and stores it in moveInput
    public void OnMove(){
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
    }

    /// Reads the input for jumping and applies an upward force
    public void OnJump(){
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Update() {
        //Move the character based on the input
        Vector3 targetVelocity = new Vector3(moveInput.x, 0f, moveInput.y) * maxSpeed;
        rigidBody.velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, targetVelocity, acceleration * Time.deltaTime);

        //Apply gravity to the character
        rigidBody.AddForce(Vector3.down * 9.8f, ForceMode.Acceleration);
    }
}