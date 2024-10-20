using UnityEngine;

[CreateAssetMenu(menuName = "FSM/AlertState")]
public class AlertState : StateBlueprint
{
	public float rotationSpeed = 90f;
	public float forwardOffsetAngle = 1f;
	private float totalRotationAngle;
	private Transform playerTransform;
	private Transform myTransform;
	private VisionManager visionManager;

	public override void OnEnter(FSM fsm)
	{
		visionManager = fsm.GetComponent<VisionManager>();
		myTransform = fsm.GetComponent<Transform>();
		totalRotationAngle = 0f;
		playerTransform = fsm.player.transform;
	}

	public override void OnStay(FSM fsm)
	{
		totalRotationAngle += Rotate();

		if (visionManager.isTargetSeen(fsm.player, fsm.hearDistance))
		{
			var player2DPosition = new Vector2(playerTransform.position.x, playerTransform.position.z);
			var my2DPosition = new Vector2(myTransform.position.x, myTransform.position.z);
			var playerDistance = Vector2.Distance(my2DPosition, player2DPosition);

			if (playerDistance < fsm.attackDistance)
			{
				fsm.ChangeState("Attack");
			}
			else if (playerDistance < fsm.hearDistance)
			{
				fsm.ChangeState("Chase");
			}
		}

		if (totalRotationAngle >= 360f)
		{
			fsm.ChangeState("Idle");
		}
	}

	public override void OnExit(FSM fsm)
	{
	}

	public float Rotate()
	{
		float rotationAngle = rotationSpeed * Time.deltaTime;
		myTransform.Rotate(Vector3.up * rotationAngle);
		return rotationAngle;
	}
}