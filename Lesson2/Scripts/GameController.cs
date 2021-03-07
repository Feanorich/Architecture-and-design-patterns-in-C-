using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {
        private ListUpdates _listUpdates;

        void Awake()
        {
            _listUpdates = new ListUpdates();
        }


        void Update()
        {
            _listUpdates.GameUpdates(Time.deltaTime);
        }
    }
}
