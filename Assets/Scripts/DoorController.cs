using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum Type
    {
        Auto,
        Score,
        Key,
    }

    public Type type;
    public GameObject[] doorRenderers;
    private bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (!doorRenderers.Contains(other.gameObject) && CanOpenDoor(other))
        {
            foreach (var door in doorRenderers)
            {
                OpenDoor(door);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!doorRenderers.Contains(other.gameObject))
        {
            foreach (var door in doorRenderers)
            {
                CloseDoor(door);
            }
        }
    }

    private bool CanOpenDoor(Collider other)
    {
        switch (type)
        {
            case Type.Auto:
                return true;
            case Type.Score:
                return isScoreReached(other);
            case Type.Key:
                return hasKey;
            default:
                return false;
        }
    }

    private void OpenDoor(GameObject door)
    {
        door.SetActive(false);
    }

    private void CloseDoor(GameObject door)
    {
        door.SetActive(true);
    }

    private bool isScoreReached(Collider other)
    {
        ScoreManager score = other.GetComponent<ScoreManager>();
        if (score)
        {
            return score.isScoreReached();
        }
        return false;
    }

    public void PickUpKey()
    {
        hasKey = true;
    }
}