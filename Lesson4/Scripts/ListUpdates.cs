using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ListUpdates
    {
        private List<IUpdate> Updates = new List<IUpdate>();              

        public void GameUpdates(float deltaTime)
        {
            for (int i = 0; i < Updates.Count; i++)
            {
                Updates[i].GameUpdate(deltaTime);
            }
        }

        public void AddUpdate(IUpdate _updater)
        {
            Updates.Add(_updater);
            _updater.IsDestroyed += RemoveUpdate;
            Debug.Log($">> добавлен >> {_updater}");
        }

        public void RemoveUpdate(IUpdate _updater)
        {            
            if (Updates.Remove(_updater))
            {
                Debug.Log($"<< удален << {_updater}");
            }
        }
    }
}
