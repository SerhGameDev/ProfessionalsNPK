using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Core.Game.Quiz
{
    public sealed class ButtonLetter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textMesh;

        private FieldText _fieldText;


        public void Init(string letter, FieldText fieldText)
        {
            _fieldText = fieldText;
            _textMesh.text = letter;
            _button.onClick.AddListener(Click);
        }

        public void Click() => _fieldText.AddLetter(_textMesh.text);

    }
}
