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
    }

    private void Update()
    {
        currentAmmo = Mathf.Clamp(currentAmmo, 0f, maxChamber);
        chamberBar.UpdateAmount(currentAmmo, maxChamber);
        if (playerInput.actions["Reload"].WasPressedThisFrame())
        {
            Reload();
        }
    }

    public void Reload()
    {
        currentAmmo += ammoManager.Reload(maxChamber - currentAmmo);
    }

    public bool Shoot()
    {
        bool canShoot = currentAmmo > 0;
        if (canShoot) currentAmmo--;
        return canShoot;
    }
}