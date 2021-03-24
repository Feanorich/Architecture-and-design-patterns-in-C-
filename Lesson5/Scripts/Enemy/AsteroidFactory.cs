using System;
using UnityEngine;

namespace Asteroids
{
    class AsteroidFactory : IEnemyFactory
    {
        protected GameObject _asteroidPrephub;

        public AsteroidFactory(GameObject asteroidPrephub)
        {
            _asteroidPrephub = asteroidPrephub;
        }
        public GameObject CreateEnemyUnit(Vector3 enemyPosition, Quaternion enemyRotation, float startSpeed)
        {
            var enemy = GameObject.Instantiate(_asteroidPrephub, enemyPosition, enemyRotation);
            var rb = enemy.GetOrAddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.AddForce(enemy.transform.up * startSpeed * rb.mass);

            ServiceLocator.Resolve<ListUpdates>().AddUpdate(enemy.GetOrAddComponent<EnemyAsteroid>());

            return enemy;
        }
    }
}
