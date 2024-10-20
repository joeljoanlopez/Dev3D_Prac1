using UnityEngine;

public class HearingManager : MonoBehaviour
{
    private FSM fsm;
    private void Start()
    {
        fsm = GetComponent<FSM>();
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, fsm.player.transform.position);
        if (playerDistance < fsm.hearDistance && fsm.currentState.canGetAggro)
        {
            fsm.ChangeState("Alert");
        }
    }
}