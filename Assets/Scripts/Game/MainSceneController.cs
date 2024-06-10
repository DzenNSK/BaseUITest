using UnityEngine;
using UnityEngine.UI;

namespace BaseUITest
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button settingsButon;

        private ScreenSettings screenSettings;

        private void Start()
        {
            GameServices.Instance.ScreenService.RegisterScreen<ScreenSettings>("Prefabs/SettingsScreen");
            screenSettings = GameServices.Instance.ScreenService.GetScreen<ScreenSettings>();
            restartButton.onClick.AddListener(OnRestartButton);
            settingsButon.onClick.AddListener(OnSettingsButton);
        }

        private void OnRestartButton()
        {
            GameServices.Instance.SoundService.PlayClick();
            var loadingScreen = GameServices.Instance.ScreenService.GetScreen<ScreenLoading>();
            loadingScreen.ReloadScene("main");
        }

        private void OnSettingsButton()
        {
            GameServices.Instance.SoundService.PlayClick();
            screenSettings.Show();
        }
    }
}
