using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Game.Quiz
{
    [RequireComponent(typeof(FieldText))]
    public sealed class Quiz : MonoBehaviour
    {
        [SerializeField] private List<QuizItem> _texts;
        
        [SerializeField] private Transform _rootLetters;
        [Header("Prefab")]
        [SerializeField] private ButtonLetter _prefabButtonLetter;
        [Header("Button")]
        [SerializeField] private Button _buttonSend;
        [SerializeField] private Button _buttonClear;

        private FieldText _fieldText;
        private List<ButtonLetter> _letters = new();
        private OpenQuiz open = 0;
        private int _level;

        private void Awake()
        {
            _fieldText = GetComponent<FieldText>();

            if (_buttonSend != null)
                _buttonSend.onClick.AddListener(Send);

            if (_buttonClear != null)
                _buttonClear.onClick.AddListener(Clear);
        }

        private void Start()
        {
            ShowQuiz();
        }

        public void ShowQuiz() => ShowButtonLetters();

        public void ShowButtonLetters()
        {
            string randomLetters = "";

            if (OpenQuiz.BuildingName == open)
                randomLetters = ShuffleLettersInWords(_texts[_level].BuildingName);

            if (OpenQuiz.City == open)
                randomLetters = ShuffleLettersInWords(_texts[_level].City);

            if (OpenQuiz.Сountry == open)
                randomLetters = ShuffleLettersInWords(_texts[_level].Сountry);

            _letters.Clear();
            _rootLetters.Cast<Transform>().ToList().ForEach(child => Destroy(child));

            foreach (char c in randomLetters.ToCharArray())
            {
                var letter = Instantiate(_prefabButtonLetter, _rootLetters);
                letter.Init(c.ToString(), _fieldText);
                _letters.Add(letter);
            }
        }

        public void Send()
        {
            string buildingNameText = _texts[_level].City;
            if (OpenQuiz.BuildingName == open && _fieldText.TextMesh.text == _texts[_level].BuildingName)
            {
                open = OpenQuiz.City;
                _fieldText.TextMesh.text = buildingNameText;
                return;
            }

            string cityText = buildingNameText + _texts[_level].City;
            if (OpenQuiz.City == open && _fieldText.TextMesh.text == cityText)
            {
                open = OpenQuiz.BuildingName;
                _fieldText.TextMesh.text = cityText;
                return;
            }

        }

        public void Clear()
        {
            _fieldText.ClearText();
            _letters.ForEach(letter => letter.SetActiveState());

        }

        public void OpenMene(int id) => SceneManager.LoadScene(id);

        private string ShuffleLettersInWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string[] words = text.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            for (int w = 0; w < words.Length; w++)
            {
                char[] letters = words[w].ToCharArray();

                for (int i = letters.Length - 1; i > 0; i--)
                {
                    int j = Random.Range(0, i + 1);

                    char temp = letters[i];
                    letters[i] = letters[j];
                    letters[j] = temp;
                }

                words[w] = new string(letters);
            }

            return string.Join(" ", words);
        }

        [Serializable]
        private class QuizItem
        {
            public string BuildingName;
            public string City;
            public string Сountry;
        }
        public enum OpenQuiz
        {
            BuildingName = 0,
            City = 1,
            Сountry = 2
        }
    }
}
