using UnityEngine;

namespace Asteroids
{
    public class EngineState : IState
    {
        public IState NewState { get; set; }     
        
        private IEngine _engine;
        private MoveTransform _moveTransform;
        public readonly string Name;
        public EngineState(IEngine engine, MoveTransform moveTransform, string name = "engine")
        {
            _engine = engine;
            _moveTransform = moveTransform;
            Name = name;
        }

        public void ChangeState(IStateMachine stateMachine)
        {
            stateMachine.CurrentState = NewState;
            stateMachine.CurrentState.EnterState();            
        }

        public void EnterState()
        {
            Debug.Log($"Новое состояние корабля {Name}");
            _moveTransform.MoveObject = _engine.MoveObject;
        }
    }
}
