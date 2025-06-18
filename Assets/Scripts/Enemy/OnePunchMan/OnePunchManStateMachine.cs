using StatePattern.StateMachine;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
    {
        public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            enemyStates.Add(Enemy.States.IDLE, new IdleState<OnePunchManController>(this));
            enemyStates.Add(Enemy.States.ROTATING, new RotatingState<OnePunchManController>(this));
            enemyStates.Add(Enemy.States.SHOOTING, new ShootingState<OnePunchManController>(this));
        }
    }
}