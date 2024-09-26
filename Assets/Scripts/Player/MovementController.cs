using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour {

    public float acceleration = 5f;
    public float maxSpeed = 10f;

    private PlayerInput playerInput;

    public void Start(){
        playerInput = GetComponent<PlayerInput>();
    }
}