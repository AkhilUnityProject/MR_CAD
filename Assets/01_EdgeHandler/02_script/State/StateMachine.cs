using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StateMachine : MonoBehaviour
{ 
    private State currentState;
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    public void StartState(State startState)
    {
        ChangeState(startState);
    }

   
}
