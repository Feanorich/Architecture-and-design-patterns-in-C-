namespace Asteroids
{
    public interface IStateMachine
    {
        IState CurrentState { get; set; }

        void ControlState();
    }
}
