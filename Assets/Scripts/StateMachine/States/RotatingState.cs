
using StatePattern.Enemy;
using System;
using UnityEngine;

public class RotatingState : IState
{
    private float targetRotation;
    OnePunchManStateMachine stateMachine;
    public OnePunchManController Owner { get; set; }

    public RotatingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        targetRotation = (Owner.GetCurrentRotationY() + 180) % 360;
    }

    public void OnStateExit()
    {
        targetRotation = 0;
    }

    public void Update()
    {
        Owner.SetRotation(CalculateRotation());
        if (isRotationCompleted())
        {
            stateMachine.ChangeState(OnePunchManStates.IDLE);
        }
    }

    private Vector3 CalculateRotation()
    {
        return Vector3.up * Mathf.MoveTowardsAngle(Owner.GetCurrentRotationY(), targetRotation, Owner.GetRotationSpeed() * Time.deltaTime);
    }

    private bool isRotationCompleted() => Mathf.Abs(Mathf.Abs(Owner.GetCurrentRotationY()) - Mathf.Abs(targetRotation)) < Owner.GetRotationThreshold();
}
