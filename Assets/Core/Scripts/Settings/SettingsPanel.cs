using Core.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Settings
{
    public sealed class SettingsPanel : Panel
    {
        [SerializeField] private Slider _sliderMusic;
        [SerializeField] private Slider _sliderSound;

        private void Start()
        {
            if (SoundManager.Instance == null)
                return;

            _sliderMusic.maxValue = 10;
            _sliderMusic.onValueChanged.AddListener(ChangeMusic);
            _sliderMusic.value = SoundManager.Instance.MusicVolume * _sliderMusic.maxValue;

            _sliderSound.maxValue = 10;
            _sliderSound.onValueChanged.AddListener(ChangeSound);
            _sliderSound.value = SoundManager.Instance.SfxVolume * _sliderSound.maxValue;
        }

        public void ExitGame() => Application.Quit();

        public void ChangeMusic(float value) => SoundManager.Instance.SetMusicVolume(value / _sliderMusic.maxValue);

        public void ChangeSound(float value) => SoundManager.Instance.SetSFXVolume(value / _sliderSound.maxValue);
    }
}