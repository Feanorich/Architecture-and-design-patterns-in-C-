using System.Collections.Generic;

namespace Snake
{
    public interface ISnake
    {
        List<IUnit> Chain { get; }

        IUnit AddTail();
        void CreateSnake();
    }
}