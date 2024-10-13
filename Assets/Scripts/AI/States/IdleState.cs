using UnityEngine;

[CreateAssetMenu(menuName = "FSM/IdleState")]
public class IdleState : StateBlueprint
{
    public float idleTime = 1f;
    
    private float currentTime;

    public override void OnEnter(FSM fsm)
    {
        currentTime = idleTime;
    }

    public override void OnStay(FSM fsm)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f) fsm.ChangeState("Patrol");
    }

    public override void OnExit(FSM fsm)
    {
    }
}