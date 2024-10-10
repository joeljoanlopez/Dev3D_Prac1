using UnityEngine;

[CreateAssetMenu(menuName = "States/IdleState")]
public class IdleState : StateBlueprint
{
    public float idleTime = 1f;
    private float currentTime = 0f;

    public void OnEnter(FSM fsm)
    {
        currentTime = idleTime;
    }

    public void OnStay(FSM fsm)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            fsm.ChangeState("PatrolState");
        }
    }

    public void OnExit(FSM fsm) { return; }
}