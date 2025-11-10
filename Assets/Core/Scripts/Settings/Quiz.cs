using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Core.Game.Quiz
{
    public sealed class Quiz : MonoBehaviour
    {
        [SerializeField] private ButtonLetter _prefabButtonLetter;
        [SerializeField] private string text = "Привет";
        [SerializeField] private Transform _rootLetters;

        private List<ButtonLetter> _letters = new();

        private void Start()
        {
            ShowLetters();
        }

        public void ShowLetters()
        {
            char[] letters = text.ToCharArray();
            foreach (char c in letters)
            {
                var letter = Instantiate(_prefabButtonLetter, _rootLetters);
                letter.SetText(c.ToString());
                _letters.Add(letter);
            }

        }

        public void OpenMene(int id) => SceneManager.LoadScene(id);
    }
}