using System;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour, IUpdate
    {
        private static ObjectPool _bulletsPool;
        
        [SerializeField] private float _lifetime;
        [SerializeField] private float _damage = 1;
        private GameObject _bullet;

        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        static Bullet()
        {
            _bulletsPool = new ObjectPool(Resources.Load<GameObject>("Bullet"));
        }

        public void Awake()
        {
            _bullet = gameObject;
            _lifetime = 5;
        }

        private void OnCollisionEnter2D(Collision2D other)
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
            var temAmmunition = bulletObject.GetComponent<Rigidbody2D>();

            temAmmunition.AddForce(barrel.up * force);

            var _newBullet = bulletObject.GetOrAddComponent<Bullet>();
            if (lifetime > 0)
            {
                _newBullet._lifetime = lifetime;
            }
            
            ListUpdates.AddUpdate(_newBullet);
        }
    }
}
