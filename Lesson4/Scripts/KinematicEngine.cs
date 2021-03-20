using UnityEngine;

namespace Asteroids
{
    class KinematicEngine : IEngine
    {
        public void MoveObject(Transform transform, float horizontal, float vertical,
            float speed, float deltaTime)
        {
            Vector3 _move = new Vector3();
            var _speed = deltaTime * speed;
            _move.Set(horizontal * _speed, vertical * _speed, 0.0f);
            transform.localPosition += _move;
        }
    }
}
