using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Unit : IUnit
    {
        public int X { get; set; }
        public int Y { get; set; }

        private GameObject _unit;
        public Unit(GameObject unit)
        {
            _unit = unit;
            X = (int)_unit.transform.position.x;
            Y = (int)_unit.transform.position.y;
        }

        public IUnit MoveUnit(int x, int y)
        {
            Vector3 newPos = new Vector3((float)x, (float) y, 0.0f);
            _unit.transform.position = newPos;
            X = x;
            Y = y;

            return this;
        } 
        
        public void Destroy()
        {
            GameObject.Destroy(_unit);
            X = -2;
            Y = -2;
        }
    }
}
