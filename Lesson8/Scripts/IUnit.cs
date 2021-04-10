using UnityEngine;

namespace Snake
{
    public interface IUnit
    {
        int X { get; set; }
        int Y { get; set; }

        IUnit MoveUnit(int x, int y);
        void Destroy();
    }
}
