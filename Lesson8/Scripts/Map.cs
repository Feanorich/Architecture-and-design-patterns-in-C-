using System;
using UnityEngine;

namespace Snake
{
    public class Map : IMap
    {       
        private IUnit[,] _map;
        private Vector3 wallPosition = new Vector3();
        private Quaternion wallRotation = Quaternion.identity;
        GameObject wall;
        GameObject walls;
        private int _x;
        private int _y;

        public int SizeX { get { return _x; } }
        public int SizeY { get { return _y; } }
        public Map(int sizeX, int sizeY)
        {
            wall = Resources.Load<GameObject>("Wall");
            walls = new GameObject("Walls");            

            _map = new IUnit[sizeX, sizeY];
            _x = sizeX - 1;
            _y = sizeY - 1;

            CreateMap();            
        }
        private string WallName(Vector3 pos)
        {
            return $"Wall({pos.x},{pos.y})";
        }
        private void HorisontalWall(int y)
        {
            wallPosition.y = y;
            for (int i = -1; i <= (_x + 1); i++)
            {
                wallPosition.x = i;
                GameObject.Instantiate(wall, wallPosition, wallRotation, walls.transform)
                    .name = WallName(wallPosition);
            }
        }

        private void VerticalWall(int x)
        {
            wallPosition.x = x;
            for (int i = 0; i <= _y; i++)
            {
                wallPosition.y = i;
                GameObject.Instantiate(wall, wallPosition, wallRotation, walls.transform)
                    .name = WallName(wallPosition); ;
            }
        }
        private void CreateMap()
        {
            if (wall != null)
            {
                HorisontalWall(-1);
                HorisontalWall(_y + 1);
                VerticalWall(-1);
                VerticalWall(_x + 1);
            }
            else
            {
                Debug.LogError("Нет префаба стены");
            }         
        }

        private bool CheckFrontier(int x, int y)
        {
            if ((x >= 0) && (x <= _x) && (y >= 0) && (y <= _y))
            {
                return true;
            }
            return false;
        }

        public void Add(IUnit unit)
        {            
            if (CheckFrontier(unit.X, unit.Y))
            {
                _map[unit.X, unit.Y] = unit;
            }
            else
            {
                Debug.LogError($"Добавить на ({unit.X},{unit.Y}) нельзя");
            }
        }
        public void Remove(IUnit unit)
        {
            if (CheckFrontier(unit.X, unit.Y))
            {
                _map[unit.X, unit.Y] = null;
            }
            else
            {
                Debug.LogError($"Убрать из ({unit.X},{unit.Y}) нельзя");
            }            
        }

        public bool CheckWallCollision(int x, int y)
        {
            if (x < 0 || x > _x) return true;
            if (y < 0 || y > _y) return true;
            return false;
        }
        public bool CheckUnitCollision(int x, int y, out IUnit unit)
        {
            unit = _map[x, y];
            if (unit != null) { return true; };
            return false;
        }

        public void ClearMap()
        {
            for (int x = 0; x <= _x; x++)
            {
                for (int y = 0; y <= _y; y++)
                {
                    if (_map[x, y] != null)
                    {
                        _map[x, y].Destroy();
                        _map[x, y] = null;
                    }                    
                }
            }
        }
    }
}
