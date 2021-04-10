using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class GameStatus : IGameStatus
    {
        public event Action RestartGame = delegate () { };

        private IGameUI _gameUI;
        private bool _endGame;

        public GameStatus(IGameUI gameUI)
        {
            _gameUI = gameUI;
            _endGame = false;
        }
        public void SetPause()
        {
            Time.timeScale = 0;
            Debug.LogWarning("PaUsE");

            _gameUI.ShowUI(_gameUI.Pause);
        }
        public void GamePause()
        {
            if (Time.timeScale == 1) 
            {
                SetPause();
            }
            else 
            {
                Time.timeScale = 1;
                Debug.LogWarning("pLay");
                _gameUI.HideUI();

                if (_endGame)
                {
                    RestartGame.Invoke();
                    _endGame = false;
                    Time.timeScale = 0;
                    Debug.LogWarning("New Game");
                }                
            }
        }          

        public void WinGame()
        {
            Time.timeScale = 0;
            Debug.LogWarning("ПОБЕДА");
            _endGame = true;

            _gameUI.ShowUI(_gameUI.Win);
        }

        public void LooseGame()
        {
            Time.timeScale = 0;
            Debug.LogWarning("Сасат");
            _endGame = true;

            _gameUI.ShowUI(_gameUI.Loose);
        }

        public void ExitGame()
        {
            SetPause();
            Debug.LogWarning("ВыХоД");
            Application.Quit();
        }
    }
}
