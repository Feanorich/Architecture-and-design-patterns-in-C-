using UnityEngine;

namespace Asteroids
{
    public interface IPlayerShip
    {
        void ShipControl(Transform transform, float deltaTime);
    }
}
