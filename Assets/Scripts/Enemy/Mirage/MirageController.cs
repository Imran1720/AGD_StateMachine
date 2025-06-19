using StatePattern.Player;
using System;

namespace StatePattern.Enemy
{
    public class MirageController : EnemyController
    {
        private MirageStateMachine stateMachine;
        public int CloneCount { get; set; }
        public MirageController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            SetCloneCount(enemyScriptableObject.CloneCount);
            ChangeEnemyColor(EnemyColorType.Default);
            CreateStateMachine();
            stateMachine.ChangeState(StateMachine.States.IDLE);
        }

        public void SetCloneCount(int val) => CloneCount = val;

        private void CreateStateMachine()
        {
            stateMachine = new MirageStateMachine(this);
        }

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
            {
                return;
            }
            stateMachine.Update();
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

        public override void Die()
        {
            enemyView.Print("Clone count " + CloneCount);
            if (CloneCount > 0)
            {
                stateMachine.ChangeState(StateMachine.States.CLONE);
            }
            base.Die();
        }

        public void Teleport()
        {
            stateMachine.ChangeState(StateMachine.States.TELEPORTING);
        }
        public void SetDefaultColor() => enemyView.ChangeColor(EnemyColorType.Default);

        public void ChangeColor(EnemyColorType type) => enemyView.ChangeColor(type);
    }
}
