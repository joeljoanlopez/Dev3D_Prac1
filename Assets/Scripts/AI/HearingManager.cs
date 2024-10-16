using UnityEngine;

public class HearingManager : MonoBehaviour
{
    private float detectionRange;
    private FSM fsm;
    private void Start()
    {
        fsm = GetComponent<FSM>();
        detectionRange = fsm.detectionRange;
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, fsm.player.transform.position);
        if (playerDistance < detectionRange)
        {
            fsm.ChangeState("Alert");
        }
    }
}