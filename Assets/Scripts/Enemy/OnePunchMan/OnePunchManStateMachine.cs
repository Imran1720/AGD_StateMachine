using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : IStateMachine
    {
        private OnePunchManController Owner;
        private IState currentState;
        protected Dictionary<States, IState> EnemyStates = new Dictionary<States, IState>();

        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            EnemyStates.Add(Enemy.States.IDLE, new IdleState(this));
            EnemyStates.Add(Enemy.States.ROTATING, new RotatingState(this));
            EnemyStates.Add(Enemy.States.SHOOTING, new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in EnemyStates.Values)
            {
                state.Owner = Owner;
            }
        }

        public void Update() => currentState?.Update();

        protected void ProcessState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(States newState) => ProcessState(EnemyStates[newState]);

    }

    public enum States
    {
        IDLE,
        ROTATING,
        SHOOTING,
        PATROLLING,
        CHASING
    }
}