using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "FSM/AttackState")]
public class AttackState : StateBlueprint
{
    [Header("Attack Parameters")]
    public float damage = 10f;
    public float range = 10f;
    public float fireRate = 1f;

    private float nextFire;
    private ParticleSystem[] shootEffects;

    public override void OnEnter(FSM fsm)
    {
        nextFire = fireRate;
        shootEffects = fsm.GetComponentsInChildren<ParticleSystem>();
    }

    public override void OnStay(FSM fsm)
    {
        if (fsm.player == null)
        {
            Debug.LogError("FSM has no player");
            return;
        }

        nextFire -= Time.deltaTime;

        if (nextFire <= 0)
        {
            Attack(fsm.player);
            nextFire = fireRate;
        }

        float playerDistance = Vector3.Distance(fsm.transform.position, fsm.player.transform.position);

        if (playerDistance > fsm.attackDistance)
        {
            fsm.ChangeState("Chase");
        }
    }

    public override void OnExit(FSM fsm) { } //Nothing

    private void Attack(GameObject target)
    {
        var shieldManager = target.GetComponent<ShieldManager>();
        if (shieldManager != null)
        {
            shieldManager.TakeDamage(damage);
            nextFire = fireRate;
            foreach (var effect in shootEffects)
            {
                effect.Play();
            }
        }
        else
        {
            Debug.LogWarning("Target does not have a Shield Manager");
        }
    }
}