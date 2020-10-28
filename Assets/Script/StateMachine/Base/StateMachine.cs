using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previousState;

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();
        if(targetState == null)
        {
            Debug.LogWarning("cannot change to state, as it " +
                " does not exist on the state machine object." +
                " make sure you have the disired state attached" +
                " to the state machine!");
            return;

        }

        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if(_previousState != null)
        {
            InitiateStateChange(_previousState);
        }
    }

    void InitiateStateChange(State targetState)
    {
        if (_currentState != targetState)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        InTransition = true;

        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();

        InTransition = false;
    }

    private void Update()
    {
        if(CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}
