using UnityEngine;
using TMPro;

namespace Core.Game.Quiz
{
    public class FieldText : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI TextMesh { get; private set; }

        private void Start() => ClearText();

        public void AddLetter(string letter) => TextMesh.text += letter;

        public void ClearText() => TextMesh.text = "ЭТО - ";

    }
}