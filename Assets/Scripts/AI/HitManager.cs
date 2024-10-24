﻿using UnityEngine;

public class HitManager : MonoBehaviour
{
    public StateBlueprint hitState;
    public float score = 50f;

    private FSM fsm;
    private HealthManager healthManager;
    private bool wasJustHit;

    private void Start()
    {
        wasJustHit = false;
        fsm = GetComponentInParent<FSM>();
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        if (wasJustHit)
        {
            wasJustHit = false;
            fsm?.ChangeState(hitState.name);
        }
    }

    public void Hit(float amount, GameObject source)
    {
        wasJustHit = true;
        source.transform.parent.GetComponentInParent<ScoreManager>()?.AddScore(score);
        Debug.Log($"The hit owner is {source.transform.parent.transform.parent.name}");


        healthManager?.TakeDamage(amount);
    }
}