using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Path path;
    public float speed = 5f;
    public float changeOffset = 0.01f;

    private Transform currentNode;
    bool isMoving = false;

    void Start()
    {
        isMoving = false;
        currentNode = path.GetNextNode(currentNode);
        transform.position = currentNode.position;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentNode.position, speed * Time.deltaTime);
        }
    }

    public void Move()
    {
        isMoving = true;
    }

    public void NextNode()
    {
        currentNode = path.GetNextNode(currentNode);
        isMoving = false;
    }

    public bool ArrivedAtNode()
    {
        return Vector3.Distance(transform.position, currentNode.position) < changeOffset;
    }
}