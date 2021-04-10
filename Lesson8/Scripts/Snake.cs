using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Snake : ISnake
    {
        private GameObject _head;
        private GameObject _body;
        private GameObject _snake;
        private IMap _map;

        private List<IUnit> _chain;
        private int _snakeLenght;
        private int _startX = 0;
        private int _startY = 0;

        public List<IUnit> Chain { get { return _chain; } }

        public Snake(IMap map, int snakeLenght = 1)
        {
            if (snakeLenght < 1) snakeLenght = 1;

            _map = map;
            _snakeLenght = snakeLenght;
            _chain = new List<IUnit>();

            _head = Resources.Load<GameObject>("Head");
            _body = Resources.Load<GameObject>("body");
            _snake = new GameObject("Snake");

            CreateSnake();
        }
        public void CreateSnake()
        {
            _chain.Clear();
            _chain.Add(new Unit(GameObject.Instantiate(_head, _snake.transform)));
            if (_snakeLenght > 1)
            {
                for (int i = 2; i <= _snakeLenght; i++)
                {
                    AddTail();
                }
            }

            for (int i = 0; i < _chain.Count; i++)
            {
                _map.Add(_chain[_chain.Count - i - 1].MoveUnit(_startX + i, _startY));
            }
        }

        public IUnit AddTail()
        {
            IUnit tail = new Unit(GameObject.Instantiate(_body, _snake.transform));
            _chain.Add(tail);
            tail.MoveUnit(-2, -2);            

            return tail;
        }        
    }
}
