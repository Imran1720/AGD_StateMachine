using StatePattern.Main;
using StatePattern.Player;
using System;
using Unity.VisualScripting;

namespace StatePattern.Enemy
{
    public class ChasingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private PlayerController target;
        public ChasingState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            SetTarget();
            SetStoppingDistance();
        }

        private void SetStoppingDistance() => Owner.Agent.stoppingDistance = Owner.Data.PlayerStoppingDistance;

        private void SetTarget() => target = GameService.Instance.PlayerService.GetPlayer();

        public void OnStateExit() => target = null;
        public void Update()
        {
            MoveTowardsTarget();
            if (ReachedDestination())
            {
                ResetPath();
                stateMachine.ChangeState(States.SHOOTING);
            }
        }

        private void ResetPath()
        {
            Owner.Agent.isStopped = true;
            Owner.Agent.ResetPath();
        }

        private bool ReachedDestination() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;

        private void MoveTowardsTarget() => Owner.Agent.SetDestination(target.Position);
    }
}
