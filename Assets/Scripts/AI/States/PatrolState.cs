using UnityEngine;

[CreateAssetMenu(menuName = "FSM/PatrolState")]
public class PatrolState : StateBlueprint
{
    private PathFollower path;
    public float rotationSpeed = 5f;
    private bool isRotationComplete;

    public override void OnEnter(FSM fsm)
    {
        path = fsm.PathFollower;
        isRotationComplete = false;
        RotateToNode(fsm.transform, path.CurrentNode);
        path.Move();
    }

    public override void OnStay(FSM fsm)
    {
        if (!isRotationComplete)
        {
            isRotationComplete = RotateToNode(fsm.transform, path.CurrentNode);
        }
        else
        {
            path.Move();

            if (path.ArrivedAtNode())
            {
                path.GoNext();
                fsm.ChangeState("Idle");
            }
        }
    }

    public override void OnExit(FSM fsm)
    {
        path.Stop();
    }

    private bool RotateToNode(Transform from, Transform node)
    {
        if (node)
        {
            Vector3 direction = node.position - from.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            from.rotation = Quaternion.Slerp(from.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(from.rotation, targetRotation) < 0.1f)
            {
                return true;
            }
        }
        return false;
    }
}