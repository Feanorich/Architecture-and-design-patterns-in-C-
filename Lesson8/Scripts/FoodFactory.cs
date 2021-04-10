using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class FoodFactory : IFoodFactory
    {
        private IMap _map;
        private GameObject _food;
        private List<(int x, int y)> _places;
        private IUnit unit;
        private System.Random _random;

        public FoodFactory(IMap map)
        {
            _map = map;
            _food = Resources.Load<GameObject>("Food");
            _random = new System.Random();
            _places = new List<(int x, int y)>();
            StartFood();
        }

        private IUnit CreateFood()
        {
            IUnit food = new Unit(GameObject.Instantiate(_food));
            return food;
        }

        public IUnit StartFood()
        {
            int x = _map.SizeX / 2;
            int y = _map.SizeY / 2;
            IUnit food = CreateFood();
            food.MoveUnit(x, y);
            _map.Add(food);
            return food;
        }
        public IUnit RandomFood()
        {
            _places.Clear();
            for (int x = 0; x <= _map.SizeX; x++)
            {
                for (int y = 0; y <= _map.SizeY; y++)
                {
                    if (!_map.CheckUnitCollision(x, y, out unit))
                    {
                        _places.Add((x, y));
                    }
                }
            }
            Debug.Log(_places.Count);

            if (_places.Count > 0)
            {
                IUnit food = CreateFood();
                int i = _random.Next(0, _places.Count - 1);
                food.MoveUnit(_places[i].x, _places[i].y);
                _map.Add(food);
                return food;
            }
            else
            {
                return null;
            }
        }

        public void DestroyFood(IUnit food)
        {
            food.Destroy();
            _map.Remove(food);            
        }
    }
}
