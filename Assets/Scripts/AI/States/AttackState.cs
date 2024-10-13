using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "FSM/AttackState")]
public class AttackState : StateBlueprint
{
    [Header("Attack Parameters")] public float damage = 10f;

    public float range = 10f;
    public float fireRate = 1f;
    private float nextFire;

    public override void OnEnter(FSM fsm)
    {
        ResetCooldown();
    }

    public override void OnStay(FSM fsm)
    {
        if (IsNull(fsm.player)) return;

        UpdateCooldown();

        if (nextFire <= 0)
        {
            Attack(fsm.player);
            ResetCooldown();
        }
    }

    public override void OnExit(FSM fsm)
    {
        // No specific exit logic
    }

    private void Attack(GameObject target)
    {
        var healthManager = target.GetComponent<HealthManager>();

        if (healthManager != null)
        {
            healthManager.TakeDamage(damage);
            nextFire = fireRate; // Restart cooldown
        }
        else
        {
            Debug.LogWarning("Target does not have a Health Manager");
        }
    }

    private void UpdateCooldown()
    {
        nextFire -= Time.deltaTime;
    }

    private void ResetCooldown()
    {
        nextFire = fireRate;
    }

    private bool IsNull(GameObject target)
    {
        if (target == null)
        {
            Debug.LogWarning("FSM player is null.");
            return true;
        }

        return false;
    }
}