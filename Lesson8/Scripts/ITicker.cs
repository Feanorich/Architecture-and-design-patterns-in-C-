using System;

namespace Snake
{
    public interface ITicker : IUpdate
    {
        event Action Tick;
    }
}