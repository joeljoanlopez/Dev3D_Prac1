using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum Type
    {
        Health,
        Shield,
        Ammo,
    }

    public Type type;
    public float amount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (RecieveItem(other))
        {
            Destroy(gameObject);
        }
    }

    private bool RecieveItem(Collider other)
    {
        switch (type)
        {
            case Type.Health:
                HealthManager healthManager = other.GetComponent<HealthManager>();
                return healthManager.AddHealth(amount);
            case Type.Ammo:
                AmmoManager ammoManager = other.gameObject.GetComponent<AmmoManager>();
                return ammoManager.AddAmmo(amount);
            case Type.Shield:
                ShieldManager shieldManager = other.GetComponent<ShieldManager>();
                return shieldManager.AddShield(amount);
            default:
                return false;
        }
    }
}