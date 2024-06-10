using UnityEngine;
using UnityEngine.UI;

namespace BaseUITest
{
    public class ScreenGreetengs : UIScreenBase
    {
        [SerializeField] private Button nextButton;

        private void Start()
        {
            nextButton?.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            GameServices.Instance.SoundService.PlayClick();
            onAnimationComplete += LoadMainScene;
            Hide();
        }

        private void LoadMainScene()
        {
            onAnimationComplete -= LoadMainScene;
            var loadingScreen = GameServices.Instance.ScreenService.GetScreen<ScreenLoading>();
            loadingScreen.ReloadScene("main");
        }

    }
}
