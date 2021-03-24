using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    class AsteroidController : EnemyController
    {
        public List<EnemyAsteroid> Asteroids;
        private IEnemyFactory _asteroidFactory;

        private float _startSpeed = 30;
        private int _numberOfEnemy = 1;

        public AsteroidController(GameObject enemyPrephub, int numberOfEnemy) : base(enemyPrephub)
        {
            _asteroidFactory = new AsteroidFactory(enemyPrephub);
            _numberOfEnemy = numberOfEnemy;

            Asteroids = new List<EnemyAsteroid>(_numberOfEnemy);

            for (int i = 1; i <= _numberOfEnemy; i++)
            {
                Vector3 pos = new Vector3(Random.Range(TransformPosition.MinX, TransformPosition.MaxX),
                    TransformPosition.MaxY, 0);
                Vector3 pos2 = new Vector3(Random.Range(TransformPosition.MinX, TransformPosition.MaxX),
                    TransformPosition.MinY, 0);
                Vector3 relativePos = pos2 - pos;
                Quaternion dir = Quaternion.LookRotation(relativePos);
                
                dir = Quaternion.Euler(0, 0, Random.Range(-180.0f , 180.0f));
                var asteroid = _asteroidFactory.CreateEnemyUnit(pos, dir, _startSpeed);               

            }
        }
        public override void GameUpdate(float deltaTime)
        {
            
        }
    }
}
//ServiceLocator.Resolve<ListUpdates>().AddUpdate(_bulletUpdater);