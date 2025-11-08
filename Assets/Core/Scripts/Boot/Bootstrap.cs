using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Boot
{
    /// <summary>
    /// Точка входа в сцену.
    /// </summary>
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LoadingSlider _loadingSlider;

        private void Start()
        {
            _loadingSlider.OnLoad += () => SceneManager.LoadScene("Menu");    
            _loadingSlider.StartLoading();
        }
    }
}