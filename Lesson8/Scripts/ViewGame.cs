using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class ViewGame : MonoBehaviour
    {
        private GameController _gameController;

        private void Start()
        {
            _gameController = new GameController();
        }

        private void Update()
        {
            _gameController.GameUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _gameController.GameFixedUpdate(Time.deltaTime);
        }
    }
}
