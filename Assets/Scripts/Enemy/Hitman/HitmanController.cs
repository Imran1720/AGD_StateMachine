using StatePattern.Player;
using System;

namespace StatePattern.Enemy
{

    public class HitmanController : EnemyController
    {
        private HitmanStateMachine stateMachine;
        public HitmanController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(StateMachine.States.IDLE);
        }
        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
            {
                return;
            }

            stateMachine.Update();
        }

        public override void Shoot()
        {
            base.Shoot();
            stateMachine.ChangeState(StateMachine.States.TELEPORTING);
        }

        private void CreateStateMachine()
        {
            stateMachine = new HitmanStateMachine(this);
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(StateMachine.States.CHASING);
        }

        public override void PlayerExitedRange()
        {
            stateMachine.ChangeState(StateMachine.States.IDLE);
        }
    }
}
