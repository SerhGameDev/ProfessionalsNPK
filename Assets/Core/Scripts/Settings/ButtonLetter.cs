using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Core.Game.Quiz
{
    public sealed class ButtonLetter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void SetText(string text)
        {
            _textMesh.text = text;
        }
    }
}