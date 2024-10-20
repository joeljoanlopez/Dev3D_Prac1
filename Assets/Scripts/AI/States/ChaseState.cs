using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "FSM/ChaseState", order = 0)]
public class ChaseState : StateBlueprint
{
    [Header("Distances")]

    [Header("Movement")]
    public float speed = 10f;

    private float currentChaseDistance;
    private Vector3 currentPosition;
    private Transform myTransform;

    [Header("Info")]
    private Vector3 playerPosition;

    public override void OnEnter(FSM fsm)
    {
        myTransform = fsm.transform;
    }

    public override void OnStay(FSM fsm)
    {
        UpdatePositions(fsm);
        if (currentChaseDistance < fsm.attackDistance) fsm.ChangeState("Attack");
        else if (currentChaseDistance > fsm.hearDistance) fsm.ChangeState("Alert");
        else
        {
            MoveTowardsTarget();
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
        var targetPosition = playerPosition;
        targetPosition.y = currentPosition.y;
        myTransform.position = Vector3.MoveTowards(currentPosition, playerPosition, speed * Time.deltaTime);
        Vector3 directionToPlayer = playerPosition - myTransform.position;
        if (directionToPlayer != Vector3.zero)
        {
            myTransform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}