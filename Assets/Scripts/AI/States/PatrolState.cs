using UnityEngine;

[CreateAssetMenu(menuName = "States/PatrolState")]
public class PatrolState : StateBlueprint
{
    public void OnEnter(FSM fsm)
    {
        Debug.Log("Patrolling");
    }
    public void OnStay(FSM fsm) { return; }

    public void OnExit(FSM fsm) { return; }
}