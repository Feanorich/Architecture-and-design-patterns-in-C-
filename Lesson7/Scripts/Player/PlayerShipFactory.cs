using UnityEngine;

namespace Asteroids
{
    public class PlayerShipFactory  : IPlayerShipFactory 
    {
        private Transform _transform;
        private float _speed;
        private float _acceleration;
        public PlayerShipFactory(Transform transform, float speed, float acceleration)
        {
            _transform    = transform;
            _speed        = speed;
            _acceleration = acceleration;
        }
        public IPlayerShip CreateShip()
        {
            var moveTransform = new AccelerationMove(_transform, _speed, _acceleration);
            IEngine engineD = new DynamicEngine();
            IEngine engineK = new KinematicEngine();            

            IState dynamicState = new EngineState(engineD, moveTransform, "dynamic");
            IState kinematicState = new EngineState(engineK, moveTransform, "kinematic");
            dynamicState.NewState = kinematicState;
            kinematicState.NewState = dynamicState;

            var rotation = new RotationShip(_transform);
            IPlayerShip _ship = new Ship(moveTransform, rotation, dynamicState);


            return _ship;
        }
    }
}
