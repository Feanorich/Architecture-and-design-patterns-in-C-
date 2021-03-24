using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IPlayerShip
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        private Camera _camera;

        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation)
        {
            _camera = Camera.main;

            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void ShipControl(Transform transform, float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            Rotation(direction);

            Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                RemoveAcceleration();
            }
        }
    }
}