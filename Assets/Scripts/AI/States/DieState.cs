using UnityEngine;

[CreateAssetMenu(menuName = "FSM/DieState")]
public class DieState : StateBlueprint
{
    public float rotationSpeed = 180f;
    private float currentRotation;

    public override void OnEnter(FSM fsm)
    {
        currentRotation = 0f;
    }

    public override void OnStay(FSM fsm)
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        fsm.transform.Rotate(Vector3.right, rotationAmount);
        currentRotation += rotationAmount;

        if (currentRotation >= 360f) Destroy(fsm.gameObject);
    }

    public override void OnExit(FSM fsm)
    {
        //Nothing
    }
}