using UnityEngine;

public abstract class StateBlueprint : ScriptableObject
{
    public string stateName;
    public abstract void OnEnter(FSM fsm);
    public abstract void OnStay(FSM fsm);
    public abstract void OnExit(FSM fsm);
}