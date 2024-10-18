using UnityEngine;
using UnityEngine.InputSystem;

public class ActionController : MonoBehaviour
{
    [Header("Controllers")]
    public class ActionController : MonoBehaviour
    {
        [Header("Controllers")]
        public GameObject player;
        public Camera cam;

        [Header("Effects")]
        [Header("Effects")]
        public GameObject bulletEffect;
        public ParticleSystem shootEffect;

        [Header("Gun")]

        [Header("Gun")]
        public float damage = 10f;
        public float range = 100f;
        public float shootRate = 0.5f;
        private float shootTimer = 0f;
        private ChamberManager chamberManager;


        private PlayerInput playerInput;

        private void Start()
        {
    private void Start()
        {
            playerInput = player.GetComponent<PlayerInput>();
            chamberManager = GetComponent<ChamberManager>();
        }


        private void Update()
        {
    private void Update()
        {
            shootTimer -= Time.deltaTime;
            bool canShoot = playerInput.actions["Shoot"].WasPressedThisFrame() && shootTimer <= 0f;
            if (canShoot && chamberManager.Shoot())
            {
                Shoot();
                shootTimer = shootRate;
            }
        }

        private void Shoot()
        {
    private void Shoot()
        {
            shootEffect.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage, player);
                    GameObject bullet = Instantiate(bulletEffect, hit.point, Quaternion.identity);
                    Destroy(bullet, 1f);
                }
            }

        }
    }