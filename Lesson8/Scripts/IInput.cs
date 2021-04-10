using System;

namespace Snake
{
    public interface IInput : IUpdate
    {
        event Action PressKeyUp;
        event Action PressKeyDown;
        event Action PressKeyLeft;
        event Action PressKeyRight;

        event Action PressKeyPause;
        event Action PressKeyExit;        
    }
}