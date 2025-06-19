using StatePattern.Enemy;
using StatePattern.StateMachine;
using UnityEngine;
using UnityEngine.AI;

public class TeleportingState<T> : IState where T : EnemyController
{
    public EnemyController Owner { get; set; }

    public GenericStateMachine<T> stateMachine;

    public TeleportingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Teleport();
        stateMachine.ChangeState(States.CHASING);
    }

    private void Teleport()
    {
        Owner.Agent.Warp(GetRandomPosition());
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * 5f + Owner.Position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 5f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return Owner.Data.SpawnPosition;
        }

    }

    public void OnStateExit()
    {
    }

    public void Update()
    {
    }
}
