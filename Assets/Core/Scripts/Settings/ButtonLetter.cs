using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Quiz
{
    public sealed class ButtonLetter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private GameObject _deactivPanel;
        private FieldText _fieldText;
        private bool _isActive;

        public void Init(string letter, FieldText fieldText)
        {
            _fieldText = fieldText;
            _textMesh.text = letter;
            _button.onClick.AddListener(Click);
            SetActiveState();
        }

        public void Click()
        {
            if (!_isActive)
                return;

            _fieldText.AddLetter(_textMesh.text);
            SetDeactiveState();
        }

        public void SetActiveState()
        {
            _deactivPanel.SetActive(false);
            _isActive = true;
        }

        public void SetDeactiveState()
        {
            _deactivPanel.SetActive(true);
            _isActive = false;
        }
    }
}
