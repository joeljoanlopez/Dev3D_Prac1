using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public UIFillPercentage ammoBar;
    public float maxAmmo = 50f;

    private float currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        currentAmmo = Mathf.Clamp(currentAmmo, 0f, maxAmmo);
        ammoBar.UpdateAmount(currentAmmo, maxAmmo);
    }

    public void AddAmmo(float amount)
    {
        currentAmmo += amount;
    }

    public float Reload(float amount)
    {
        float reloadAmount = currentAmmo - amount >= 0f ? amount : currentAmmo;
        currentAmmo -= amount;
        return reloadAmount;
    }
}