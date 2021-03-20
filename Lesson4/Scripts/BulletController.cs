using System;
using UnityEngine;

namespace Asteroids
{
    public class BulletController : IUpdate
    {
        private static BulletPool _bulletsPool;
        
        [SerializeField] private float _lifetime;
        [SerializeField] private float _damage = 1;
        private GameObject _bullet;

        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        static BulletController()
        {            
            _bulletsPool = ServiceLocator.Resolve<BulletPool>();
        }

        public BulletController(GameObject bullet)
        {
            _bullet = bullet;
            _lifetime = 5;
        }

        public void BulletCollision(Collision2D other)
        {
            Health.CollisionWithDamage(other, _damage);
            Destroing();
        }

        public void GameUpdate(float deltaTime)
        {
            if (_lifetime > 0)
            {
                _lifetime -= deltaTime;
            }

            if (_lifetime <= 0)
            {
                Destroing();                
            }
        }

        public void Destroing()
        {
            _bulletsPool.Push(_bullet);
            IsDestroyed.Invoke(this);
        }              

        public static void CreateBullet(Transform barrel, float force, float lifetime = 0)
        {
            (Vector3 position, Quaternion rotation) _transform = (barrel.position, barrel.rotation);

            var bulletObject = _bulletsPool.Pop(_transform);

            Bullet _newBullet = bulletObject.GetOrAddComponent<Bullet>();            
            var _bulletUpdater = _newBullet._updater;            

            if (_bulletUpdater == null)
            {
                _bulletUpdater = new BulletController(bulletObject);
            }

            _newBullet.ObjectCollision += _bulletUpdater.BulletCollision;

            if (lifetime > 0)
            {
                _bulletUpdater._lifetime = lifetime;
            }

            ServiceLocator.Resolve<ListUpdates>().AddUpdate(_bulletUpdater);

            var temAmmunition = bulletObject.GetComponent<Rigidbody2D>();
            temAmmunition.AddForce(barrel.up * force);
        }
    }
}
