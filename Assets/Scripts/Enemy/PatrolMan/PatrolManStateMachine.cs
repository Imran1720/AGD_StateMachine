using StatePattern.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            enemyStates.Add(Enemy.States.IDLE, new IdleState<PatrolManController>(this));
            enemyStates.Add(Enemy.States.PATROLLING, new PatrollingState<PatrolManController>(this));
            enemyStates.Add(Enemy.States.CHASING, new ChasingState<PatrolManController>(this));
            enemyStates.Add(Enemy.States.SHOOTING, new ShootingState<PatrolManController>(this));
        }
    }
}