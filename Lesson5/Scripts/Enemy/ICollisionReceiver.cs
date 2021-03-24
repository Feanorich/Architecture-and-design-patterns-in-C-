using UnityEngine;

namespace Asteroids
{
    public interface ICollisionReceiver
    {
        void CollisionOccurred(Collision2D other);
    }
}
