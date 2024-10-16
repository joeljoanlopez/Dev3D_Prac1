using UnityEngine;

public class KeyController : MonoBehaviour
{
    public DoorController door;

    private void OnTriggerEnter(Collider other)
    {
        door.PickUpKey();
        Destroy(gameObject);
    }
}