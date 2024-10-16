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
    public GameObject doorRenderer;
    private bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != doorRenderer && CanOpenDoor(other))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != doorRenderer)
        {
            CloseDoor();
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

    private void OpenDoor()
    {
        doorRenderer.SetActive(false);
    }

    private void CloseDoor()
    {
        doorRenderer.SetActive(true);
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