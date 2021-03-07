using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Canon : IFire
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;
        private float _lifeTime;

        private List<Bullet> _bullets = new List<Bullet>();

        public Canon(Rigidbody2D bullet, Transform barrel, float force, float lifeTime)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
            _lifeTime = lifeTime;
        }

        public void Fire(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = GameObject.Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
                var _newBullet = new Bullet(temAmmunition.gameObject, _lifeTime);
                _bullets.Add(_newBullet);
                _newBullet.BulletDestroyed += RemoveBullet;
            }

            CheckBullets(deltaTime);
        }

        private void CheckBullets(float deltaTime)
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].CheckBullet(deltaTime);
            }
        }

        private void RemoveBullet(Bullet oldBullet)
        {
            if (_bullets.Remove(oldBullet))
            {
                Debug.Log($"закончилось время у {oldBullet}");
            }
        }

        public void ClearBullets()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].DestroyBullet();
            }
            _bullets.Clear();
        }

    }
}
