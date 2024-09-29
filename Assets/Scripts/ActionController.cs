using UnityEngine;
using UnityEngine.InputSystem;

public class ActionController : MonoBehaviour {
    public GameObject player;
    public Camera camera;
    
    [Header ("Gun")]
    public float damage = 10f;
    public float range = 100f;
    public float shootRate = 15f;
    private float shootTimer = 0f;

    private PlayerInput playerInput;

    private void Start() {
        playerInput = player.GetComponent<PlayerInput>();
    }


    private void Update() {
        if (playerInput.actions["Shoot"].WasPressedThisFrame()) {
            Shoot();
        }
    }

    private void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }
    }
}