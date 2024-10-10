using UnityEngine;

public abstract class StateBlueprint : ScriptableObject
{
    public string stateName;
    public abstract void OnEnter(FSM enemyAI);
    public abstract void OnStay(FSM enemyAI);
    public abstract void OnExit(FSM enemyAI);
}
