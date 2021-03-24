using System;

namespace Asteroids
{
    public interface IUpdate
    {
        event Action<IUpdate> IsDestroyed;
        void GameUpdate(float deltaTime);
        void Destroing();
    }
}
