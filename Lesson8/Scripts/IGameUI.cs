using UnityEngine;

namespace Snake
{
    public interface IGameUI
    {
        GameObject Loose { get; }
        GameObject Pause { get; }
        GameObject Win { get; }

        void HideUI();
        void ShowUI(GameObject elementUI);
    }
}