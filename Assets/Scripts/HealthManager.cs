using UnityEngine;
using UnityEngine.InputSystem;

public class HealthManager : MonoBehaviour
{
#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif
    public UIFillPercentage healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
#if UNITY_EDITOR
        playerInput = GetComponent<PlayerInput>();
#endif
    }

    private void Update()
    {
        Mathf.Clamp(currentHealth, 0f, maxHealth);
#if UNITY_EDITOR
        if (playerInput.actions["AddShield"].WasPressedThisFrame())
        {
            AddHealth(10f);
        }
        else if (playerInput.actions["DamageShield"].WasPressedThisFrame())
        {
            TakeDamage(10f);
        }
#endif
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.UpdateAmount(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        healthBar.UpdateAmount(currentHealth);
    }

    private void Die()
    {
        Debug.Log("Died");
    }
}