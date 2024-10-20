using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    [Header("List of States")]
    public List<StateBlueprint> availableStates; // List of available states

    [Header("State Parameters")]
    public StateBlueprint initialState;
    public StateBlueprint previousState;
    public StateBlueprint currentState;

    [Header("Custom Parameters")]
    public GameObject player;
    public float attackDistance = 3f;
    public float chaseDistance = 5f;
    public float hearDistance = 7f;

    private PathFollower pathFollower;
    public PathFollower PathFollower { get { return pathFollower; } }

    public Dictionary<string, StateBlueprint> StateDictionary { get; private set; }

    private void Start()
    {
        StateDictionary = new Dictionary<string, StateBlueprint>();
        pathFollower = GetComponent<PathFollower>();

        foreach (var state in availableStates) StateDictionary[state.stateName] = state;

        ChangeState(initialState.stateName);
    }

    private void Update()
    {
        currentState?.OnStay(this);
    }

    public void ChangeState(string newState)
    {
        if (StateDictionary.ContainsKey(newState))
        {
            currentState?.OnExit(this);
            previousState = currentState;
            currentState = StateDictionary[newState];
            currentState?.OnEnter(this);
        }
        else
        {
            Debug.Log("State not found: " + newState);
        }
    }
}