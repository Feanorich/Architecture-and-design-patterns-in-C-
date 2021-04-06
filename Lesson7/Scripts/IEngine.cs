using UnityEngine;

namespace Asteroids
{
    public interface IEngine
    {
        void MoveObject(Transform transform, float horizontal, float vertical,
            float speed, float deltaTime);
    }
}
