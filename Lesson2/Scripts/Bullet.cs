using System;
using UnityEngine;

namespace Asteroids
{
    class Bullet
    {
        private float _lifetime;
        private GameObject _bullet;

        public event Action<Bullet> BulletDestroyed = delegate (Bullet ex) { };

        public Bullet(GameObject bullet, float lifetime)
        {
            _bullet = bullet;
            _lifetime = lifetime;
        }

        public void CheckBullet(float deltaTime)
        {
            if (_lifetime > 0)
            {
                _lifetime -= deltaTime;
            }

            if (_lifetime <= 0)
            {
                DestroyBullet();
                BulletDestroyed.Invoke(this);
            }
        }

        public void DestroyBullet()
        {
            GameObject.Destroy(_bullet);            
        }
    }
}
