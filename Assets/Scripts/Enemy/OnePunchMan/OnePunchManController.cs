using StatePattern.Enemy.Bullet;
using StatePattern.Main;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class OnePunchManController : EnemyController
    {
        private OnePunchManStateMachine stateMachine;

        public OnePunchManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);

            CreateStateMachine();
            stateMachine.ChangeState(OnePunchManStates.IDLE);
        }

        private void CreateStateMachine() => stateMachine = new OnePunchManStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.update();
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(OnePunchManStates.SHOOTING);

        }

        public float GetCurrentRotationY() => enemyView.transform.rotation.y;

        public Quaternion GetCurrentRotation() => enemyView.transform.rotation;

        public override void PlayerExitedRange() => stateMachine.ChangeState(OnePunchManStates.IDLE);

    }
}