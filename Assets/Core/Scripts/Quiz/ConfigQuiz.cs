using System.Collections.Generic;
using UnityEngine;


namespace Core.Game.Quiz
{
    [CreateAssetMenu(fileName = "QuizConfig", menuName = "Config/QuizConfig")]
    public class ConfigQuiz : ScriptableObject
    {
        public List<string> Strings;
    }
}