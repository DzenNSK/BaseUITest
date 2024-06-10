using UnityEngine;

namespace BaseUITest
{
    //Обычно использую Di(Zenject), но поскольку ограничение на внешние frameworks - псевдосинглтон
    public class GameServices : MonoBehaviour
    {
        [SerializeField] private ScreenService screenService;
        [SerializeField] private SoundService soundService;

        public ScreenService ScreenService => screenService;
        public SoundService SoundService => soundService;

        public static GameServices Instance { get; private set; }

        private void Start()
        {
            if (Instance == null) Instance = this;
            else
            {
                if (Instance == this) return;

                Debug.LogWarning("[GameServices] Multiple instances on scene");
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
