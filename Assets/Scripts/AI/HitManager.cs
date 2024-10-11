using UnityEngine;

public class HitManager : MonoBehaviour
{
    public string hitState;

    private bool wasJustHit;
    private FSM fsm;

    private void Start()
    {
        wasJustHit = false;
        fsm = GetComponent<FSM>();
    }

    private void Update()
    {
        if (wasJustHit)
        {
            fsm.ChangeState(hitState);
            wasJustHit = false;
        }
    }

    public void Hit()
    {
        wasJustHit = true;
    }
}