using UnityEngine;

public class HitManager : MonoBehaviour
{
    public string hitState;
    private FSM fsm;

    private bool wasJustHit;

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