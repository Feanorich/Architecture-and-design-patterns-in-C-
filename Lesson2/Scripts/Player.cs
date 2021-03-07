using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IUpdate
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

        private Camera _camera;
        private Ship _ship;
        private IFire _canon;

        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        private void Start()
        {
            _camera = Camera.main;

            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            IEngine engine = new DynamicEngine();
            moveTransform.MoveObject = engine.MoveObject;

            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _canon = new Canon(_bullet, _barrel, _force, _lifeTime);
        }

        public void GameUpdate(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            _canon.Fire(deltaTime);

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                _canon.ClearBullets();
                Destroy(gameObject);
                IsDestroyed.Invoke(this);
            }
            else
            {
                _hp--;
            }
        }
    }
}