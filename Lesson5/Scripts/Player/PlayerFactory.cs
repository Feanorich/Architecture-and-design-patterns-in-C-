using UnityEngine;

namespace Asteroids
{
    public class PlayerFactory : IPlayerFactory
    {
        public IUnit CreatePlayer()
        {
            Player player = GameObject.FindObjectOfType<Player>();
            IUnit _playerUpdater = new PlayerController(player);
            player.Unit = _playerUpdater;

            player.ObjectCollision += _playerUpdater.CollisionOccurred;

            ServiceLocator.Resolve<ListUpdates>().AddUpdate(_playerUpdater);

            return _playerUpdater;
        }
    }
}
