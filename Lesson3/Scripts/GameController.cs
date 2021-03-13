using UnityEngine;

namespace Asteroids
{
    public class GameController
    {
        private Player _player;

        public GameController()
        {
            _player = GameObject.FindObjectOfType<Player>();
            ListUpdates.AddUpdate(_player);
        }

        public void GameUpdate(float deltaTime)
        {
            ListUpdates.GameUpdates(deltaTime);
        }
    }
}
