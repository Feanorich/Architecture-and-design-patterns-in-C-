using System;
using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private Transform _transform;
        private Vector3 _move;

        public Action<Transform, float, float, float, float> MoveObject;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;

            IEngine engine = new KinematicEngine();
            MoveObject = engine.MoveObject;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            MoveObject(_transform, horizontal, vertical, Speed, deltaTime);
        }
    }
}
