
using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.Player;
using System;
using UnityEngine;

public class ShootingState : IState
{
    public OnePunchManStateMachine stateMachine;
    private PlayerController target;
    private float shootTimer;
    public OnePunchManController Owner { get; set; }


    public ShootingState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;


    public void OnStateEnter()
    {
        SetTarget();
        shootTimer = 0;
    }

    private void SetTarget()
    {
        target = GameService.Instance.PlayerService.GetPlayer();
    }

    public void OnStateExit()
    {
        target = null;
    }

    public void Update()
    {
        Quaternion desiredRotation = CalculateRotationTowardsPlayer();
        Owner.SetRotation(desiredRotation);

        if (IsRotationCompleted(desiredRotation))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                ResetTimer();
                Owner.Shoot();
            }
        }

    }

    private Quaternion CalculateRotationTowardsPlayer()
    {
        Vector3 directionToPlayer = target.Position - Owner.Position;
        directionToPlayer.y = 0f;
        return Quaternion.LookRotation(directionToPlayer, Vector3.up);
    }

    private Quaternion RotateTowards(Quaternion desiredRotation) => Quaternion.LerpUnclamped(Owner.GetCurrentRotation(), desiredRotation, Owner.GetRotationSpeed() / 30 * Time.deltaTime);

    private bool IsRotationCompleted(Quaternion desiredRotation) => Quaternion.Angle(Owner.GetCurrentRotation(), desiredRotation) < Owner.GetRotationThreshold();

    private void ResetTimer() => shootTimer = Owner.GetFireRate();

}
