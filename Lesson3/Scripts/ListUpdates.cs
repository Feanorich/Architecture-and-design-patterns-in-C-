using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static class ListUpdates
    {
        static private List<IUpdate> Updates = new List<IUpdate>();

        static ListUpdates()
        {
                       
        }

        public static void GameUpdates(float deltaTime)
        {
            for (int i = 0; i < Updates.Count; i++)
            {
                Updates[i].GameUpdate(deltaTime);
            }
        }

        public static void AddUpdate(IUpdate _updater)
        {
            Updates.Add(_updater);
            _updater.IsDestroyed += RemoveUpdate;
            Debug.Log($">> добавлен >> {_updater}");
        }

        public static void RemoveUpdate(IUpdate _updater)
        {            
            if (Updates.Remove(_updater))
            {
                Debug.Log($"<< удален << {_updater}");
            }
        }
    }
}
