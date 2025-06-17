
using StatePattern.Enemy;
using System;
using UnityEngine;

public class IdleState : IState
{
    public OnePunchManController Owner { get; set; }

    OnePunchManStateMachine stateMachine;

    private float timer;

    public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;
    public void OnStateEnter() => ResetTimer();

    private void ResetTimer()
    {
        timer = Owner.GetIdleDuration();
    }

    public void OnStateExit()
    {
        timer = 0;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.ChangeState(OnePunchManStates.ROTATING);
        }
    }
}
