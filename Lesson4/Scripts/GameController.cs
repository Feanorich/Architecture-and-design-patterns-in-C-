using UnityEngine;

namespace Asteroids
{
    public class GameController
    {
        private PlayerController _playerUpdater;
        private ListUpdates _listUpdates;

        public GameController()
        {
            _listUpdates = new ListUpdates();

            ServiceLocator.SetService<ListUpdates>(_listUpdates);
            ServiceLocator.SetService<BulletPool>(new BulletPool(Resources.Load<GameObject>("Bullet")));

            Player player = GameObject.FindObjectOfType<Player>();
            _playerUpdater = new PlayerController(player);
            player._updater = _playerUpdater;

            player.ObjectCollision += _playerUpdater.PlayerCollision;

            _listUpdates.AddUpdate(_playerUpdater);
        }

        public void GameUpdate(float deltaTime)
        {
            _listUpdates.GameUpdates(deltaTime);
        }
    }
}
