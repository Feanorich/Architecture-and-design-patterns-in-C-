using System;
using UnityEngine;

namespace Asteroids
{
    class DestroyMessage : IUpdate
    {
        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };
        
        private float _lifetime;
        private GameObject _message;

        public DestroyMessage(GameObject message, float lifetime = 1)
        {
            _message = message;
            _lifetime = lifetime;
        }
        public void Destroing()
        {
            GameObject.Destroy(_message);
            IsDestroyed.Invoke(this);
        }

        private bool TimeIsOver(ref float lifetime, float deltaTime)
        {
            if (lifetime > 0)
            {
                lifetime -= deltaTime;
            }

            if (lifetime <= 0)
            {
                return true;
            }
            return false;
        }

        public void GameUpdate(float deltaTime)
        {           
            if (TimeIsOver(ref _lifetime, deltaTime))
            {
                Destroing();
            }
        }
    }
}
