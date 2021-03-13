using UnityEngine;

namespace Asteroids
{
    interface IEngine
    {
        void MoveObject(Transform transform, float horizontal, float vertical,
            float speed, float deltaTime);
    }
}
