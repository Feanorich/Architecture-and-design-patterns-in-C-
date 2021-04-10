using System;

namespace Snake
{
    public interface IGameStatus
    {
        event Action RestartGame;
        void SetPause();
        void GamePause();
        void WinGame();
        void LooseGame();
        void ExitGame();
    }
}