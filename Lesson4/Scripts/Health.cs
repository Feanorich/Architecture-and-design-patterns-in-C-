using System;
using UnityEngine;

namespace Asteroids
{
    public class Health
    {
        private float _hp = 1;
        private IUpdate _object;

        public Health(float hp, IUpdate newObject)
        {
            _hp = hp;
            _object = newObject;
        }

        public void ChangeHP(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                _object.Destroing();
            }          
        }

        public static void CollisionWithDamage(Collision2D other, float damage = 1)
        {
            var enemyHP = other.gameObject.GetComponent<IHealth>();
            
            if (enemyHP != null)
            {
                enemyHP.Health.ChangeHP(damage);
            }
        }
    }
}
