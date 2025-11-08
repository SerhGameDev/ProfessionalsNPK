using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Boot
{
    /// <summary>
    /// ”правл€ет визуализацией процесса "загрузки" на слайдере.
    /// —чЄт идет по времени, после достижени€ заданного времени вызывает событие OnLoad.
    /// </summary>
    public sealed class LoadingSlider : MonoBehaviour
    {
        public event Action OnLoad;
        [HideInInspector] public bool IsLoad;

        [SerializeField] private float _requiredTime = 2;
        [SerializeField] private float _valueTime = 0;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textMesh;
        private float _percent => Mathf.Clamp01(_valueTime / _requiredTime) * 100f;

        private void Start()
        {
            SetupSlider();
        }

        private void Update()
        {
            if (!IsLoad)
                return;

            ChangeTime();
            View();
        }

        [ContextMenu("StartLoading")]
        public void StartLoading()
        {
            SetupSlider();
            IsLoad = true;
            _valueTime = 0;
        }

        [ContextMenu("EndLoading")]
        public void EndLoading()
        {
            IsLoad = false;
            _valueTime = _requiredTime;
            OnLoad?.Invoke();
        }

        private void View()
        {
            ViewLoadingSlider();
            ViewLoadingText();
        }

        private void ChangeTime()
        {
            if (_valueTime >= _requiredTime)
            {
                EndLoading();
                return;
            }

            _valueTime += Time.deltaTime;
        }

        private void SetupSlider()
        {
            if (_slider == null)
                return;

            _slider.maxValue = 100;
            _slider.value = 0;

            ViewLoadingText();
            ViewLoadingSlider();
        }

        private void ViewLoadingSlider()
        {
            if (_slider == null)
                return;

            _slider.value = _percent;
        }

        private void ViewLoadingText()
        {
            if (_textMesh == null)
                return;

            _textMesh.text = Math.Round(_percent, 1) + " %";
        }
    }

}
