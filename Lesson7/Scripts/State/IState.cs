namespace Asteroids
{
    public interface IState
    {
        IState NewState { get; set; } 
        void EnterState();
        void ChangeState(IStateMachine stateMachine);
    }
}
