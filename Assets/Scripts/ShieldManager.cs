using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldManager : MonoBehaviour
{
#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif
    public UIFillPercentage shieldBar;
    public float maxShield = 100f;
    public float shieldReductionPercentage = 75f;
    private float currentShield;
    private HealthManager healthManager;

    private void Start()
    {
        currentShield = maxShield;
        healthManager = GetComponent<HealthManager>();
        shieldBar.UpdateAmount(currentShield, maxShield);
#if UNITY_EDITOR
        playerInput = GetComponent<PlayerInput>();
#endif
    }

    private void Update()
    {
        currentShield = Mathf.Clamp(currentShield, 0f, maxShield);
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
        shieldBar.UpdateAmount(currentShield, maxShield);
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
        shieldBar.UpdateAmount(currentShield, maxShield);
    }
}