using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    public float acceleration = 5f;
    public float maxSpeed = 10f;

    private PlayerInput playerInput;

    private Vector2 moveInput;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(){
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log("Move Input: " + moveInput);
    }

    public void OnJump(){

    }

    private void Update() {
        Vector3 targetVelocity = new Vector3(moveInput.x, 0f, moveInput.y) * maxSpeed;
        GetComponent<Rigidbody>().velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, targetVelocity, acceleration * Time.deltaTime);
    }
}