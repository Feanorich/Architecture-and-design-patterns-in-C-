using System;
using UnityEngine;

namespace Asteroids
{
    public class PlayerController : IUnit 
    {
        private Player _player;
        private PlayerData _playerData;    
        
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

        public PlayerController(Player player)
        {
            _player = player;                        
            _playerData = _player.PlayerData;

            IPlayerShipFactory _shipFactory = new PlayerShipFactory(_player.transform, _playerData.Speed,
                _playerData.Acceleration);

            _ship = _shipFactory.CreateShip();

            IWeaponFactory _weaponFactory = new CanonFactory(_playerData.Bullet.gameObject,
                _player._barrel, _playerData.Force, _playerData.LifeTime);
            _canon = _weaponFactory.CreateWeapon();

            _health = new Health(_playerData.Hp, this);
        }

        public void GameUpdate(float deltaTime)
        {
            _ship.ShipControl(_player.transform, deltaTime);

            _canon.Fire(deltaTime);

            TransformPosition.ScreenControl(_player.transform);

            if (Input.GetKeyDown(KeyCode.N))
            {
                var g = new GameObject().SetName($"go {deltaTime}");
            }
        }

        public void CollisionOccurred(Collision2D other)
        {
            Health.CollisionWithDamage(other, _playerData.Hp);
        }

        public void Destroing()
        {
            GameObject.Destroy(_player.gameObject);
            IsDestroyed.Invoke(this);
        }
    }
}