using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/ChaseState", order = 0)]
public class ChaseState : StateBlueprint
{
    [Header("Distances")] 
    public float chaseDistance = 50f;
    public float maxChaseDistance = 100f;
    private float currentChaseDistance;

    [Header("Movement")] public float speed = 10f;

    [Header("Info")] 
    private Vector3 playerPosition;
    private Vector3 currentPosition;
    private Transform myTransform;

    public override void OnEnter(FSM fsm)
    {
        myTransform = fsm.transform;
    }

    public override void OnStay(FSM fsm)
    {
        UpdatePositions(fsm);
        MoveTowardsTarget();
        if (currentChaseDistance < chaseDistance)
        {
            fsm.ChangeState("Attack");
        }
        else if (currentChaseDistance > maxChaseDistance)
        {
            fsm.ChangeState("Alert");
        }
    }

    public override void OnExit(FSM fsm)
    {
        // Nothing
    }

    private void UpdatePositions(FSM fsm)
    {
        playerPosition = fsm.player.transform.position;
        currentPosition = myTransform.position;
        currentChaseDistance = Vector3.Distance(playerPosition, currentPosition);
    }

    private void MoveTowardsTarget()
    {
        myTransform.position = Vector3.MoveTowards(currentPosition, this.playerPosition, speed * Time.deltaTime);
    }
}