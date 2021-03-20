using System;
using UnityEngine;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IUpdate, IHealth
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp = 1;
                
        public event Action<IUpdate> IsDestroyed = delegate (IUpdate ex) { };

        private Health _health;

        public Health Health 
        {
            get
            {
                return _health;
            }
        }


        void Start()
        {
            _health = new Health(_hp, this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Health.CollisionWithDamage(other, 10);
        }

        public void GameUpdate(float deltaTime)
        {
            
        }

        public void Destroing()
        {
            Destroy(gameObject);
            IsDestroyed.Invoke(this);
        }
    }
}