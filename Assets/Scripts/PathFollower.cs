using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Path path;
    public float speed = 5f;
    public float changeOffset = 0.01f;

    private Transform currentNode;
    public Transform CurrentNode { get { return currentNode; } }
    private bool isMoving;

    private void Start()
    {
        isMoving = false;
        GoNext();
        transform.position = currentNode.position;
    }

    private void Update()
    {
        if (isMoving)
            transform.position = Vector3.MoveTowards(transform.position, currentNode.position, speed * Time.deltaTime);
    }

    public void Move()
    {
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }

    public Transform GoNext()
    {
        currentNode = path.GetNextNode(currentNode);
        return currentNode;
    }

    public bool ArrivedAtNode()
    {
        return Vector3.Distance(transform.position, currentNode.position) < changeOffset;
    }
}