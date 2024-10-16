using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthManager : MonoBehaviour
{
    public UIFillPercentage healthBar;
    public float maxHealth = 100f;

    private float currentHealth;

#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif

    private void Start()
    {
        currentHealth = maxHealth;

#if UNITY_EDITOR
        playerInput = GetComponent<PlayerInput>();
#endif
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (healthBar != null) healthBar.UpdateAmount(currentHealth, maxHealth);

#if UNITY_EDITOR
        if (playerInput.actions["AddHealth"].WasPressedThisFrame())
            AddHealth(10f);
        else if (playerInput.actions["DamageHealth"].WasPressedThisFrame()) TakeDamage(10f);
#endif
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
        FSM fsm = GetComponent<FSM>();
        if (fsm)
        {
            fsm.ChangeState("Die");
        }
        else
        {
            Debug.Log("You Died");
        }
    }
}