using UnityEngine;

namespace BaseUITest
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundSource;

        private const string soundStateKey = "SoundState";
        private const string musicStateKey = "MusicState";

        private bool soundsState;
        private bool musicState;

        public bool SoundsState => soundsState;
        public bool MusicState => musicState;

        public void SetMusic(bool state)
        {
            musicState = state;
            musicSource.mute = !musicState;
            SavePrefs();
        }

        public void SetSounds(bool state)
        {
            soundsState = state;
            SavePrefs();
        }

        public void PlayClick()
        {
            if (soundsState)
            {
                soundSource.Play();
            }
        }

        private void SavePrefs()
        {
            PlayerPrefs.SetInt(soundStateKey, soundsState ? 1 : 0);
            PlayerPrefs.SetInt(musicStateKey, musicState ? 1 : 0);
            PlayerPrefs.Save();
        }

        private void RestorePrefs()
        {
            soundsState = PlayerPrefs.HasKey(soundStateKey) ? PlayerPrefs.GetInt(soundStateKey)!=0 : true;
            musicState = PlayerPrefs.HasKey(musicStateKey) ? PlayerPrefs.GetInt(musicStateKey)!=0 : true;
        }

        private void Start()
        {
            RestorePrefs();
            musicSource.mute = !musicState;
        }
    }
}
