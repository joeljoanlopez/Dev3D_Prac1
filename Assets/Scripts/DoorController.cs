using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

public class DoorController : MonoBehaviour
{
    public enum Type
    {
        Auto,
        Score,
        Key,
    }

    public Type type;
    public Animator animator;
    private bool hasKey;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanOpenDoor(other))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
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
        // door.SetActive(false);
        animator.SetBool("open", true);
    }

    private void CloseDoor()
    {
        // door.SetActive(true);
        animator.SetBool("open", false);
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