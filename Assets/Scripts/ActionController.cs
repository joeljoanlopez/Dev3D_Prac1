using UnityEngine;
using UnityEngine.InputSystem;

public class ActionController : MonoBehaviour {
    [Header ("Controllers")]
    public GameObject player;
    public Camera camera;

    [Header ("Effects")]
    public GameObject bulletEffect;
    public ParticleSystem shootEffect;
    
    [Header ("Gun")]
    public float damage = 10f;
    public float range = 100f;
    public float shootRate = 0.5f;
    private float shootTimer = 0f;


    private PlayerInput playerInput;

    private void Start() {
        playerInput = player.GetComponent<PlayerInput>();
    }


    private void Update() {
        shootTimer -= Time.deltaTime;
        bool canShoot = playerInput.actions["Shoot"].ReadValue<float>() == 1 && shootTimer <= 0f;
        if (canShoot) {
            Shoot();
            shootTimer = shootRate;
        }
    }

    private void Shoot(){
        shootEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) 
                target.TakeDamage(damage);
        }

        GameObject bullet = Instantiate(bulletEffect, hit.point, Quaternion.identity);
    }
}