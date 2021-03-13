using UnityEngine;

namespace Asteroids
{
    public class Canon : IWeapon
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;
        private float _lifeTime;

        public Canon(Rigidbody2D bullet, Transform barrel, 
            float force, float lifeTime)
        {
            _bullet   = bullet;
            _barrel   = barrel;
            _force    = force;
            _lifeTime = lifeTime;
        }

        public void Fire(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Bullet.CreateBullet(_barrel, _force, _lifeTime);
            }
        }        
    }
}
