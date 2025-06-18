namespace StatePattern.Enemy
{
    public interface IStateMachine
    {
        void ChangeState(States newState);
        void Update();

    }
}