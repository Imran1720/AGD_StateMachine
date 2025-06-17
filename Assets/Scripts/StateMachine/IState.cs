using StatePattern.Enemy;

public interface IState
{
    public OnePunchManController Owner { get; set; }
    void OnStateEnter();
    void Update();
    void OnStateExit();
}
