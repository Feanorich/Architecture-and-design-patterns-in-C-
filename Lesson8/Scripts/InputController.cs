using System;
using UnityEngine;

namespace Snake
{
    public class InputController : IInput
    {
        public event Action PressKeyUp = delegate () { };
        public event Action PressKeyDown = delegate () { };
        public event Action PressKeyLeft = delegate () { };
        public event Action PressKeyRight = delegate () { };
        public event Action PressKeyPause = delegate () { };
        public event Action PressKeyExit = delegate () { };

        public void GameUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W)) PressKeyUp.Invoke();
            if (Input.GetKeyDown(KeyCode.S)) PressKeyDown.Invoke();
            if (Input.GetKeyDown(KeyCode.A)) PressKeyLeft.Invoke();
            if (Input.GetKeyDown(KeyCode.D)) PressKeyRight.Invoke();

            if (Input.GetKeyDown(KeyCode.Space)) PressKeyPause.Invoke();
            if (Input.GetKeyDown(KeyCode.Escape)) PressKeyExit.Invoke();
        }
    }
}
