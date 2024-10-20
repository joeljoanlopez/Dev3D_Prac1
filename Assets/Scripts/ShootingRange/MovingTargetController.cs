using UnityEngine;

public class MovingTargetController : MonoBehaviour
{
    private PathFollower pathFollower;

    private void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    private void Update()
    {
        if (pathFollower.ArrivedAtNode())
        {
            pathFollower.GoNext();
        }
    }
}