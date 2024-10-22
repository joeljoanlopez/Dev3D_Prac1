using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public UIFillPercentage healthBar;
    public float maxHealth = 100f;

    private float currentHealth;

    [SerializeField] private Vector3 respawnPoint;
    public static Vector3 staticRespawnPoint;
    private void Start()
    {
        currentHealth = maxHealth;
        staticRespawnPoint= respawnPoint;
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar?.UpdateAmount(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    public bool AddHealth(float amount)
    {
        if (currentHealth >= maxHealth) return false;
        currentHealth += amount;
        return true;
    }

    private void Die()
    {
        GetComponentInParent<FSM>()?.ChangeState("Die");

        
        transform.position = staticRespawnPoint;
    }
}