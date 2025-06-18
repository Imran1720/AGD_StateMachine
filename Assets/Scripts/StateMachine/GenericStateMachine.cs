
using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections.Generic;

public class GenericStateMachine<T> where T : EnemyController
{
    protected T Owner;
    protected IState currentState;
    protected Dictionary<States, IState> enemyStates = new Dictionary<States, IState>();

    public GenericStateMachine(T Owner) => this.Owner = Owner;

    public void Update() => currentState?.Update();

    protected void ProcessState(IState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States state) => ProcessState(enemyStates[state]);

    protected void SetOwner()
    {
        foreach (IState state in enemyStates.Values)
        {
            state.Owner = Owner;
        }
    }
}
