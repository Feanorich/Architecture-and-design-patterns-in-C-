using System;

namespace Snake
{
    public class Ticker : ITicker
    {
        public event Action Tick = delegate () { };

        private float _tickLength;
        private float _tickTime = 0.0f;

        public Ticker(float tickLength)
        {
            _tickLength = tickLength;
        }

        public void GameUpdate(float deltaTime)
        {
            _tickTime += deltaTime;
            if (_tickTime >= _tickLength)
            {
                _tickTime = 0.0f;
                Tick.Invoke();
            }
        }
    }
}
