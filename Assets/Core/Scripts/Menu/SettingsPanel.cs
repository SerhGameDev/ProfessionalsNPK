using UnityEngine;

namespace Core.Menu
{
    public sealed class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public void Show()
        {
            _panel.SetActive(true);
        }

        public void Hide()
        {
            _panel.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}