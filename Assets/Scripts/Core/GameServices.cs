using UnityEngine;

namespace BaseUITest
{
    //������ ��������� Di(Zenject), �� ��������� ����������� �� ������� frameworks - ��������������
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
