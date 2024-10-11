using UnityEngine;

[CreateAssetMenu(menuName = "FSM/DieState")]
public class DieState : StateBlueprint
{
    public float deathTime = 1f;
    private float currentTime;

    public override void OnEnter(FSM fsm)
    {
        currentTime = deathTime;
    }

    public override void OnStay(FSM fsm)
    {
        UpdateTimer();
        if (currentTime <= 0)
        {
            Destroy(fsm.gameObject);
        }
    }

    public override void OnExit(FSM fsm)
    {
        //Nothing
    }

    private void UpdateTimer()
    {
        currentTime -= Time.deltaTime;
    }
}