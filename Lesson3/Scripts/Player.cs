using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IUpdate, IHealth
    {
        [Header("Мобильность")]
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [Header("Оружие")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _lifeTime;

        private IPlayerShip _ship;
        private IWeapon _canon;
        private Health _health;

        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        public Health Health
        {
            get
            {
                return _health;
            }
        }

        private void Start()
        {
            IPlayerShipFactory _shipFactory = new PlayerShipFactory(transform, _speed, _acceleration);
            _ship = _shipFactory.CreateShip();

            IWeaponFactory _weaponFactory = new CanonFactory(_bullet.gameObject, 
                _barrel, _force, _lifeTime);
            _canon = _weaponFactory.CreateWeapon();

            _health = new Health(_hp, this);
        }

        public void GameUpdate(float deltaTime)
        {
            _ship.ShipControl(transform, deltaTime);

            _canon.Fire(deltaTime);

            TransformPosition.ScreenControl(transform);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Health.CollisionWithDamage(other, _hp);
        }

        public void Destroing()
        {
            Destroy(gameObject);
            IsDestroyed.Invoke(this);
        }
    }
}