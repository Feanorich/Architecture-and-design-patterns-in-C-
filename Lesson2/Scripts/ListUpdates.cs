using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    class ListUpdates
    {
        public List<IUpdate> Updates = new List<IUpdate>();
        private Player _player;

        public ListUpdates()
        {
            _player = GameObject.FindObjectOfType<Player>();
            
            Updates.Add(_player);
            _player.IsDestroyed += RemoveUpdate;
        }

        public void GameUpdates(float deltaTime)
        {
            foreach (var updateObject in Updates)
            {
                updateObject.GameUpdate(deltaTime);
            }
        }

        public void RemoveUpdate(IUpdate _updater)
        {            
            if (Updates.Remove(_updater))
            {
                Debug.Log($"удален {_updater}");
            }
        }
    }
}
