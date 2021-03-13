using UnityEngine;

namespace Asteroids
{
    public class ViewController : MonoBehaviour
    {
        private GameController _gameController;

        void Awake()
        {
            _gameController = new GameController();
        }

        void Update()
        {
            _gameController.GameUpdate(Time.deltaTime);
        }
    }
}
