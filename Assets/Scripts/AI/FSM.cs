using System;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public List<StateBlueprint> availableStates;  // List of available states
    public StateBlueprint initialState;
    private Dictionary<string, StateBlueprint> stateDictionary; // Dictionary of available states
    public Dictionary<string, StateBlueprint> StateDictionary { get { return stateDictionary; } }

    private StateBlueprint currentState;
    public PathFollower pathFollower;

    private void Start()
    {
        stateDictionary = new Dictionary<string, StateBlueprint>();
        pathFollower = GetComponent<PathFollower>();

        foreach (var state in availableStates)
        {
            stateDictionary[state.stateName] = state;
        }

        ChangeState(initialState.stateName);
    }

    private void Update()
    {
        currentState?.OnStay(this);
    }

    public void ChangeState(string newState)
    {
        if (stateDictionary.ContainsKey(newState))
        {
            currentState?.OnExit(this);
            currentState = stateDictionary[newState];
            currentState?.OnEnter(this);
        }
        else
        {
            Debug.Log("State not found: " + newState);
        }
    }
}
