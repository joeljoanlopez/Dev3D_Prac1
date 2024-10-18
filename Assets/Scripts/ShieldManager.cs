using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldManager : MonoBehaviour
{
    public UIFillPercentage shieldBar;
    public float maxShield = 100f;
    public float shieldReductionPercentage = 75f;
    private float currentShield;
    private HealthManager healthManager;

#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif

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
        currentShield = Mathf.Clamp(currentShield, 0f, maxShield);
        shieldBar.UpdateAmount(currentShield, maxShield);

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
    }
}