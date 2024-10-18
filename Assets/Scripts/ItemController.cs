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
                return healthManager ? healthManager.AddHealth(amount) : false;
            case Type.Ammo:
                AmmoManager ammoManager = other.gameObject.GetComponentInChildren<AmmoManager>();
                return ammoManager ? ammoManager.AddAmmo(amount) : false;
            case Type.Shield:
                ShieldManager shieldManager = other.GetComponent<ShieldManager>();
                return shieldManager ? shieldManager.AddShield(amount) : false;
            default:
                return false;
        }
    }
}