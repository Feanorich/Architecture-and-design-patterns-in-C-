using UnityEngine;

namespace Asteroids
{
    public interface IPlayerFactory
    {
        IUnit CreatePlayer();
    }
}
