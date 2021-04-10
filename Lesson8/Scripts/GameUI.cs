using System;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class GameUI : IGameUI
    {
        private GameObject _canvas;
        private GameObject _pause;
        private GameObject _win;
        private GameObject _loose;
        private GameObject _start;

        public GameObject Pause { get { return _pause; } }
        public GameObject Win { get { return _win; } }
        public GameObject Loose { get { return _loose; } }

        public GameUI()
        {
            GameObject canvas = Resources.Load<GameObject>("UI/UI");
            GameObject pause = Resources.Load<GameObject>("UI/Pause");
            GameObject win = Resources.Load<GameObject>("UI/Win");
            GameObject loose = Resources.Load<GameObject>("UI/Loose");
            GameObject start = Resources.Load<GameObject>("UI/Start");

            _canvas = GameObject.Instantiate(canvas);
            _pause = GameObject.Instantiate(pause, _canvas.transform);
            _win = GameObject.Instantiate(win, _canvas.transform);
            _loose = GameObject.Instantiate(loose, _canvas.transform);
            _start = GameObject.Instantiate(start, _canvas.transform);

            HideUI();
        }

        public void HideUI()
        {
            _pause.SetActive(false);
            _win.SetActive(false);
            _loose.SetActive(false);
            _start.SetActive(false);
        }
        public void ShowUI(GameObject elementUI)
        {
            HideUI();
            elementUI.SetActive(true);
            _start.SetActive(true);
        }
    }
}
