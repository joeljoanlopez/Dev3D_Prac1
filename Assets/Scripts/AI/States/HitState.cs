using UnityEngine;

[CreateAssetMenu(menuName = "FSM/HitState")]
public class HitState : StateBlueprint
{
    public float hitStunTime = 0.5f;
    private float currentTime;

    public override void OnEnter(FSM fsm)
    {
        currentTime = hitStunTime;
    }

    public override void OnStay(FSM fsm)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) fsm.ChangeState(fsm.previousState.stateName);
    }

    public override void OnExit(FSM fsm)
    {
    }
}