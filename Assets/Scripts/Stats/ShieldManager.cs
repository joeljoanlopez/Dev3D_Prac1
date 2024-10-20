using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldManager : MonoBehaviour
{
    public UIFillPercentage shieldBar;
    public float maxShield = 100f;
    public float shieldReductionPercentage = 75f;

    private float currentShield;
    private HealthManager healthManager;

    private void Start()
    {
        currentShield = maxShield;
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        currentShield = Mathf.Clamp(currentShield, 0f, maxShield);
        shieldBar.UpdateAmount(currentShield, maxShield);
    }

    public bool AddShield(float amount)
    {
        if (currentShield >= maxShield) return false;
        currentShield += amount;
        return true;
    }

    public void TakeDamage(float amount)
    {
        if (currentShield > 0)
        {
            var shieldDamage = amount * shieldReductionPercentage / 100;
            currentShield -= shieldDamage;
            healthManager.TakeDamage(amount - shieldDamage);
        }
        else
        {
            healthManager.TakeDamage(amount);
        }
    }
}