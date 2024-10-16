using UnityEngine;

public class HitManager : MonoBehaviour
{
    public string hitState;
    public float score = 50f;

    private FSM fsm;
    private HealthManager healthManager;
    private bool wasJustHit;

    private void Start()
    {
        wasJustHit = false;
        fsm = GetComponent<FSM>();
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        if (wasJustHit)
        {
            wasJustHit = false;
            fsm?.ChangeState(hitState);
        }
    }

    public void Hit(float amount, GameObject source)
    {
        wasJustHit = true;
        var scoreManager = source.GetComponent<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(score);
        }
        healthManager?.TakeDamage(amount);
    }
}