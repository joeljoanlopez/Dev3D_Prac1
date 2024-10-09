using System;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T> where T : Enum
{
    public T currentState;

    Dictionary<T, FSMState> AllStates;

    public FSM(T initState)
    {
        AllStates = new Dictionary<T, FSMState>();
        foreach (T state in Enum.GetValues(typeof(T)))
        {
            AllStates.Add(state, new FSMState());
        }
    }

    public void Update()
    {
        AllStates[currentState].onStay?.Invoke();
    }

    public void ChangeState(T newState)
    {
        AllStates[currentState].onExit?.Invoke();
        currentState = newState;
        AllStates[currentState].onEnter?.Invoke();
    }

    public void SetOnStay(T state, Action action)
    {
        AllStates[state].onStay = action;
    }

    public void SetOnEnter(T state, Action action)
    {
        AllStates[state].onEnter = action;
    }

    public void SetOnExit(T state, Action action)
    {
        AllStates[state].onExit = action;
    }
}