using System;

namespace Snake
{
    public interface IMove
    {
        event Action CollisionOccurred;
        event Action MapIsFull;
        void SetInput(IInput inputController);
        void Move();
        void Restart();
    }
}