using UnityEngine;
using UnityEngine.UI;

namespace BaseUITest
{
    public class ScreenSettings : UIScreenBase
    {
        [SerializeField] private Toggle soundToggle;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Button continueButton;

        private void Start()
        {
            Refresh();
            soundToggle.onValueChanged.AddListener(OnSoundsStateChange);
            musicToggle.onValueChanged.AddListener(OnMusicStateChange);
            continueButton.onClick.AddListener(OnContinueButton);
        }

        private void Refresh()
        {
            soundToggle.isOn = GameServices.Instance.SoundService.SoundsState;
            musicToggle.isOn = GameServices.Instance.SoundService.MusicState;
        }

        private void OnSoundsStateChange(bool state)
        {
            GameServices.Instance.SoundService.SetSounds(state);
        }

        private void OnMusicStateChange(bool state)
        {
            GameServices.Instance.SoundService.SetMusic(state);
        }

        private void OnContinueButton()
        {
            GameServices.Instance.SoundService.PlayClick();
            Hide();
        }

        public override void Show(bool animated = true)
        {
            Refresh();
            base.Show(animated);
        }
    }
}
