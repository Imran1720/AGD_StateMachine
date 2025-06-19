using StatePattern.Main;
using StatePattern.StateMachine;
using System;

namespace StatePattern.Enemy
{
    public class CloneState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CloneState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            CreateClone();
            CreateClone();
        }

        private void CreateClone()
        {
            MirageController mirageController = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as MirageController;
            mirageController.SetCloneCount((Owner as MirageController).CloneCount - 1);
            mirageController.Teleport();
            mirageController.ChangeColor(EnemyColorType.Clone);
            GameService.Instance.EnemyService.AddEnemy(mirageController);
        }

        public void OnStateExit()
        {
        }

        public void Update()
        {
        }
    }
}
