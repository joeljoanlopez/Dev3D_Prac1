using UnityEngine;

public class StateBlueprint : ScriptableObject
{
    public string stateName;
    public virtual void OnEnter(FSM enemyAI) { return; }
    public virtual void OnStay(FSM enemyAI) { return; }
    public virtual void OnExit(FSM enemyAI) { return; }
}
