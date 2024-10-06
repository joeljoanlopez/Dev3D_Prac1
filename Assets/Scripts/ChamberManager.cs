using UnityEngine;
using UnityEngine.InputSystem;

public class ChamberManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public UIFillPercentage chamberBar;
    public float maxChamber = 10f;

    private float currentAmmo;
    private AmmoManager ammoManager;

    private void Start()
    {
        currentAmmo = maxChamber;
        ammoManager = GetComponent<AmmoManager>();
        chamberBar.UpdateAmount(currentAmmo, maxChamber);
    }

    private void Update()
    {
        currentAmmo = Mathf.Clamp(currentAmmo, 0f, maxChamber);
        if (playerInput.actions["Reload"].WasPressedThisFrame())
        {
            Reload();
        }
    }

    public void Reload()
    {
        currentAmmo += ammoManager.Reload(maxChamber - currentAmmo);
        chamberBar.UpdateAmount(currentAmmo, maxChamber);
    }

    public bool Shoot()
    {
        bool canShoot = currentAmmo > 0;
        if (canShoot) currentAmmo--;
        chamberBar.UpdateAmount(currentAmmo, maxChamber);
        return canShoot;
    }
}