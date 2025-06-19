using StatePattern.StateMachine;
using System;

namespace StatePattern.Enemy
{
    public class MirageStateMachine : GenericStateMachine<MirageController>
    {
        public MirageStateMachine(MirageController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<MirageController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<MirageController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<MirageController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<MirageController>(this));
            States.Add(StateMachine.States.TELEPORTING, new TeleportingState<MirageController>(this));
            States.Add(StateMachine.States.CLONE, new CloneState<MirageController>(this));
        }
    }
}
