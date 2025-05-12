using UnityEngine;

public abstract class State
{
    protected GameObject gameObject;
    protected StateMachine stateMachine;

    public State(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateState() { }
    public virtual void Exit() { }
}
