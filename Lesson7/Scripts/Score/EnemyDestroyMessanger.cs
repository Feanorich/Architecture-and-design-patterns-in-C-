using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    class EnemyDestroyMessanger : IDestroyMessage
    {
        private ListUpdates _listUpdates;
        private GameObject _message;
        private Canvas _canvas;

        public EnemyDestroyMessanger()
        {
            _listUpdates = ServiceLocator.Resolve<ListUpdates>();
            _message = Resources.Load<GameObject>("DestroyMessage");
            _canvas = GameObject.FindObjectOfType<Canvas>();
            _message.transform.SetParent(_canvas.transform);
        }

        public void AddUnit(IUpdate unit)
        {
            unit.IsDestroyed += UnitDestroyed;
        }        

        public void UnitDestroyed(IUpdate unit)
        {
            Debug.Log("BAAAAANG");

            if (unit as EnemyAsteroid != null)
            {
                Debug.Log(_message);

                Vector3 unitPosition = (unit as EnemyAsteroid).gameObject.transform.position;
                unitPosition = Camera.main.WorldToScreenPoint(unitPosition);                
                var message = GameObject.Instantiate(_message, unitPosition, Quaternion.identity, _canvas.transform);

                _listUpdates.AddUpdate(new DestroyMessage(message));

                unit.IsDestroyed -= UnitDestroyed;
            }
        }
    }
}
