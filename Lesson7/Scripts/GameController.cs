using UnityEngine;

namespace Asteroids
{
    public class GameController
    {        
        private ListUpdates _listUpdates;

        private int _numberOfAsteroids = 4;

        public GameController()
        {
            _listUpdates = new ListUpdates();

            ServiceLocator.SetService<ListUpdates>(_listUpdates);
            ServiceLocator.SetService<BulletPool>(new BulletPool(Resources.Load<GameObject>("Bullet")));
            ServiceLocator.SetService<IDestroyMessage>(new EnemyDestroyMessanger());

            IPlayerFactory playerFactory = new PlayerFactory();

            playerFactory.CreatePlayer();            

            var asteroidsController = new AsteroidController(Resources.Load<GameObject>("EnemyAsteroid"), 
                _numberOfAsteroids);
            _listUpdates.AddUpdate(asteroidsController);
        }

        public void GameUpdate(float deltaTime)
        {
            _listUpdates.GameUpdates(deltaTime);
        }
    }
}
