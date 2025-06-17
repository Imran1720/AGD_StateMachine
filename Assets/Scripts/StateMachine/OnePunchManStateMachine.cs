using StatePattern.Enemy;
using System;
using System.Collections.Generic;

public class OnePunchManStateMachine
{
    private IState currentState;
    private OnePunchManController owner;
    protected Dictionary<OnePunchManStates, IState> states = new Dictionary<OnePunchManStates, IState>();


    public OnePunchManStateMachine(OnePunchManController owner)
    {
        this.owner = owner;
        CreateStates();
        SetOwner();
    }

    private void SetOwner()
    {
        foreach (var state in states)
        {
            state.Value.Owner = owner;
        }
    }

    private void CreateStates()
    {
        states.Add(OnePunchManStates.IDLE, new IdleState(this));
        states.Add(OnePunchManStates.ROTATING, new RotatingState(this));
        states.Add(OnePunchManStates.SHOOTING, new ShootingState(this));
    }

    public void update()
    {
        currentState?.Update();
    }
    protected void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(OnePunchManStates newState) => ChangeState(states[newState]);
}
