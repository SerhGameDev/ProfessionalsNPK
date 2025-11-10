using UnityEngine;

namespace Core.Infrastructure
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(AudioSource))]
    public sealed class SoundManager : MonoBehaviourSinglton<SoundManager>
    {
        [field: SerializeField][Range(0f, 1f)] public float MusicVolume { get; private set; } = 1f;
        [field: SerializeField][Range(0f, 1f)] public float SfxVolume { get; private set; } = 1f;

        private AudioSource _musicSource;

        protected override void Awake()
        {
            base.Awake();
            _musicSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            UpdateVolumes();
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (_musicSource.clip == clip)
                return;

            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.Play();
        }


        public void SetMusicVolume(float value)
        {
            MusicVolume = Mathf.Clamp01(value);
            _musicSource.volume = MusicVolume;
        }

        public void SetSFXVolume(float value)
        {
            SfxVolume = Mathf.Clamp01(value);
        }

        private void UpdateVolumes()
        {
            _musicSource.volume = MusicVolume;
        }
    }
}