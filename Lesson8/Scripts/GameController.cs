using UnityEngine;

namespace Snake
{   
    public class GameController 
    {
        private IMap _map;
        private IInput _input;
        private ITicker _ticker;
        private ISnake _snake;
        private IMove _moveSnake;
        private IGameStatus _gameStatus;
        private IFoodFactory _foodFactory;
        private IGameUI _gameUI;

        private int   _mapWidth         = 18;
        private int   _mapHeight        = 10;
        private int   _snakeStartLenght = 3;
        private float _tickLength       = 0.5f;

        public GameController()
        {
            _map = new Map(_mapWidth, _mapHeight);            

            _gameUI = new GameUI();

            _gameStatus = new GameStatus(_gameUI);
            _gameStatus.RestartGame += RestartGame;

            _input = new InputController();
            _input.PressKeyPause += _gameStatus.GamePause;
            _input.PressKeyExit += _gameStatus.ExitGame;

            _snake = new Snake(_map, _snakeStartLenght);

            _foodFactory = new FoodFactory(_map);

            _moveSnake = new MoveSnake(_snake, _map, _foodFactory);
            _moveSnake.SetInput(_input);
            _moveSnake.CollisionOccurred += _gameStatus.LooseGame;
            _moveSnake.MapIsFull += _gameStatus.WinGame;

            _ticker = new Ticker(_tickLength);
            _ticker.Tick += _moveSnake.Move;

            _gameStatus.SetPause();
        }

        public void GameUpdate(float deltaTime)
        {
            _input.GameUpdate(deltaTime);
        }
        public void GameFixedUpdate(float deltaTime)
        {
            _ticker.GameUpdate(deltaTime);
        }

        private void RestartGame()
        {
            _map.ClearMap();
            _snake.CreateSnake();
            _moveSnake.Restart();
            _foodFactory.StartFood();
            _gameStatus.SetPause();
        }
        private void DebugTicker()
        {
            Debug.Log($"тикнуло {Time.time}");
        }
    }
}