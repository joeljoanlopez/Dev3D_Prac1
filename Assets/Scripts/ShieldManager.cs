using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldManager : MonoBehaviour
{
#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif
    public UIFillPercentage shieldBar;
    private HealthManager healthManager;
    public float maxShield = 100f;
    public float shieldReductionPercentage = 75f;
    private float currentShield;

    private void Start()
    {
        currentShield = maxShield;
        healthManager = GetComponent<HealthManager>();
#if UNITY_EDITOR
        playerInput = GetComponent<PlayerInput>();
#endif
    }

    private void Update()
    {
        Mathf.Clamp(currentShield, 0f, maxShield);
#if UNITY_EDITOR
        if (playerInput.actions["AddShield"].WasPressedThisFrame())
        {
            AddShield(10f);
        }
        else if (playerInput.actions["DamageShield"].WasPressedThisFrame())
        {
            TakeDamage(10f);
        }
#endif
    }

    public void AddShield(float amount)
    {
        currentShield += amount;
        shieldBar.UpdateAmount(currentShield);
    }

    public void TakeDamage(float amount)
    {
        if (currentShield > 0)
        {
            float shieldDamage = amount * shieldReductionPercentage / 100;
            currentShield -= shieldDamage;
            healthManager.TakeDamage(amount - shieldDamage);
        }
        else
        {
            healthManager.TakeDamage(amount);
        }
        shieldBar.UpdateAmount(currentShield);
    }
}