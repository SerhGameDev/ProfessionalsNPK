using UnityEngine;
namespace Core.Infrastructure
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] protected GameObject _panel;

        public void Show()
        {
            _panel.SetActive(true);
        }

        public void Hide()
        {
            _panel.SetActive(false);
        }
    }
}