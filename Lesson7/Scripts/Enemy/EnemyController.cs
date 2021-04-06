using System;
using UnityEngine;

namespace Asteroids
{
    public abstract class EnemyController : IUpdate
    {
        protected GameObject _enemyPrephub;

        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        public abstract void GameUpdate(float deltaTime);       

        public EnemyController(GameObject enemyPrephub)
        {
            _enemyPrephub = enemyPrephub;
        }

        public virtual void Destroing()
        {
            IsDestroyed.Invoke(this);
        }
    }
}
