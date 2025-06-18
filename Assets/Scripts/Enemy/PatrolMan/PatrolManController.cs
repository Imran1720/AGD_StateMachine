using StatePattern.Player;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManController : EnemyController
    {
        private PatrolManStateMachine stateMachine;

        public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(Enemy.States.IDLE);
        }

        private void CreateStateMachine() => stateMachine = new PatrolManStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(Enemy.States.CHASING);
        }

        public override void PlayerExitedRange() => stateMachine.ChangeState(Enemy.States.IDLE);
    }
}