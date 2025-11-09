using UnityEngine;

namespace Core.Menu
{
    [RequireComponent (typeof (MiniGamePanel))]
    [RequireComponent(typeof(SettingsPanel))]

    public class Menu : MonoBehaviour
    {
        private MiniGamePanel _miniGamePanel;
        private SettingsPanel _settingsPanel;

        private void Awake()
        {
            _miniGamePanel = GetComponent<MiniGamePanel>();
            _settingsPanel = GetComponent<SettingsPanel>();
        }

        private void Start()
        {
            ShowMiniGamePanel();
        }

        public void ShowMiniGamePanel()
        {
            _miniGamePanel.Show();
            _settingsPanel.Hide();
        }

        public void ShowSettingsPanel()
        {
            _miniGamePanel.Hide();
            _settingsPanel.Show();
        }
    }
}