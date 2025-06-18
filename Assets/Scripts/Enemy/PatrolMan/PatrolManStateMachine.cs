using System;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : IStateMachine
    {
        private PatrolManController Owner;
        private IState currentState;
        protected Dictionary<States, IState> enemyStates = new Dictionary<States, IState>();

        public PatrolManStateMachine(PatrolManController controller)
        {
            Owner = controller;
            CreateStates();
            SetOwner();
        }

        private void SetOwner()
        {
            foreach (IState state in enemyStates.Values)
            {
                state.Owner = Owner;
            }
        }

        private void CreateStates()
        {
            enemyStates.Add(States.IDLE, new IdleState(this));
            enemyStates.Add(States.PATROLLING, new PatrollingState(this));
            enemyStates.Add(States.CHASING, new ChasingState(this));
            enemyStates.Add(States.SHOOTING, new ShootingState(this));

        }

        public void ProcessState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(States newState) => ProcessState(enemyStates[newState]);

        public void Update() => currentState?.Update();

    }
}