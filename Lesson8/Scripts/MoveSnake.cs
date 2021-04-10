using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class MoveSnake : IMove
    {
        enum SnakeDir { up, down, left, right }
        private Dictionary<SnakeDir, SnakeDir> _incorrectChange = new Dictionary<SnakeDir, SnakeDir> 
        {
            { SnakeDir.up, SnakeDir.down},
            { SnakeDir.down, SnakeDir.up},
            { SnakeDir.left, SnakeDir.right},
            { SnakeDir.right, SnakeDir.left}
        };

        public event Action CollisionOccurred = delegate () { };
        public event Action MapIsFull = delegate () { };

        private ISnake _snake;
        private IMap _map;
        private SnakeDir _direction;
        private SnakeDir _lastDirection;
        private IUnit _head;
        private IFoodFactory _foodFactory;

        public MoveSnake(ISnake snake, IMap map, IFoodFactory foodFactory)
        {
            _snake = snake;
            _map = map;        
            _foodFactory = foodFactory;
            Restart();
        }

        public void Move()
        {            
            int newX = _head.X;
            int newY = _head.Y;

            if (_direction == SnakeDir.up) newY += 1;
            if (_direction == SnakeDir.down) newY -= 1;
            if (_direction == SnakeDir.left) newX -= 1;
            if (_direction == SnakeDir.right) newX += 1;

            if (_map.CheckWallCollision(newX, newY))
            {
                Debug.LogError($"стена {newX},{newY} {_direction}");
                CollisionOccurred.Invoke();
            }
            else
            {
                IUnit target = null;
                if (_map.CheckUnitCollision(newX, newY, out target))
                {
                    if (BiteTail(target))
                    {
                        Debug.LogError($"укусили хвост {target.X},{target.Y} {_direction}");
                        CollisionOccurred.Invoke();
                    }
                    else
                    {
                        _snake.AddTail();                        
                        _foodFactory.DestroyFood(target);
                        MoveChain(newX, newY);
                        if (_foodFactory.RandomFood() == null)
                        {
                            MapIsFull.Invoke();
                        }                        
                    }
                }
                else
                {
                    MoveChain(newX, newY);
                }                 
            }
            _lastDirection = _direction;
        }

        public void Restart()
        {
            _direction = SnakeDir.right;
            _lastDirection = _direction;
            _head = _snake.Chain[0];
        }
        private bool BiteTail(IUnit target)
        {
            if (_snake.Chain.Contains(target))
            {
                if (_snake.Chain[_snake.Chain.Count-1] != target)
                {
                    return true;
                }
            }
            return false;
        }

        private void MoveChain(int newX, int newY)
        {
            if (_snake.Chain.Count > 1)
            {
                for (int i = _snake.Chain.Count - 1; i > 0; i--)
                {
                    var body = _snake.Chain[i];
                    var nextBody = _snake.Chain[i - 1];

                    MoveUnit(body, nextBody.X, nextBody.Y);
                }
            }
            MoveUnit(_head, newX, newY);

            for (int i = 0; i < _snake.Chain.Count; i++)
            {
                _map.Add(_snake.Chain[i]);
            }
        }

        private void MoveUnit(IUnit unit, int nextX, int nextY)
        {
            _map.Remove(unit);
            unit.MoveUnit(nextX, nextY);            
        }
         
        private SnakeDir SnakeDirection
        {
            set
            {
                if (value != _incorrectChange[_lastDirection])
                {                    
                    _direction = value;
                }
            }
        }

        private void DirectionUp() { SnakeDirection = SnakeDir.up; }
        private void DirectionDown() { SnakeDirection = SnakeDir.down; }
        private void DirectionLeft() { SnakeDirection = SnakeDir.left; }
        private void DirectionRight() { SnakeDirection = SnakeDir.right; }

        public void SetInput(IInput inputController)
        {
            inputController.PressKeyUp    += DirectionUp;
            inputController.PressKeyDown  += DirectionDown;
            inputController.PressKeyLeft  += DirectionLeft;
            inputController.PressKeyRight += DirectionRight;
        }
    }
}
