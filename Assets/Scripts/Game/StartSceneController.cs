using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseUITest
{
    public class StartSceneController : MonoBehaviour
    {
        private void Start()
        {
            GameServices.Instance.ScreenService.RegisterScreen<ScreenGreetengs>("Prefabs/GreetScreen");
            GameServices.Instance.ScreenService.RegisterScreen<ScreenLoading>("Prefabs/LoadingScreen");
            var screen = GameServices.Instance.ScreenService.GetScreen<ScreenGreetengs>();
            screen.Show();
        }
    }
}
