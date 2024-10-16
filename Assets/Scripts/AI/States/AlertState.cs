using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

[CreateAssetMenu(menuName = "FSM/AlertState")]
public class AlertState : StateBlueprint
{
	public float rotationSpeed = 90f;
	private Vector3 initialForward;
	private Vector3 currentForward;
	private Transform playerTransform;
	private Transform myTransform;
	private VisionManager visionManager;

	public override void OnEnter(FSM fsm)
	{
		initialForward = myTransform.forward;
		playerTransform = fsm.player.transform;
		myTransform = fsm.transform;
		visionManager = fsm.GetComponent<VisionManager>();
	}

	public override void OnStay(FSM fsm)
	{
		Rotate();

		if (visionManager.isTargetSeen(fsm.player))
		{
			var playerDistance = Vector3.Distance(playerTransform.position, myTransform.position);

			if (playerDistance < fsm.attackDistance)
			{
				fsm.ChangeState("Attack");
			}
			else if (playerDistance < fsm.chaseDistance)
			{
				fsm.ChangeState("Chase");
			}
		}
		else if (currentForward == initialForward)
		{
			fsm.ChangeState("Idle");
		}
	}

	public override void OnExit(FSM fsm)
	{
	}

	public void Rotate()
	{
		myTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}
}