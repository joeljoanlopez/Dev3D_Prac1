using UnityEngine;

[CreateAssetMenu(menuName = "States/PatrolState")]
public class PatrolState : StateBlueprint
{
    public PathFollower path;
    public override void OnEnter(FSM fsm)
    {
        path.Move();
    }

    public override void OnStay(FSM fsm)
    {
        if (path.ArrivedAtNode())
        {
            path.NextNode();
            fsm.ChangeState("Idle");
        }
    }

    public override void OnExit(FSM fsm) { return; }
}