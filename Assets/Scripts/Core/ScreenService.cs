using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseUITest
{
    public class ScreenService : MonoBehaviour
    {
        [SerializeField] private Canvas mainUICanvas;

        private readonly Dictionary<Type, ScreenInfo> screens = new Dictionary<Type, ScreenInfo>();

        public void RegisterScreen<T>(string resourcePath) where T : UIScreenBase
        {
            var type = typeof(T);
            if (screens.ContainsKey(type))
            {
                if (screens[type].ResourcePath == resourcePath) return;

                Debug.LogError("Screen resource overriding attempt");
                return;
            }

            var screenInfo = new ScreenInfo(typeof(T), resourcePath);
            screens.Add(typeof(T), screenInfo);
        }

        public T GetScreen<T>() where T : UIScreenBase
        {
            if (!screens.ContainsKey(typeof(T))) 
            {
                Debug.LogError($"Screen type {typeof(T)} not registered");
                return null; 
            }
            var info = screens[typeof(T)];
            var instance = info.GetInstance(mainUICanvas.transform);
            
            if (!instance.TryGetComponent<T>(out var controller))
            {
                Debug.LogError($"No {typeof(T)} component on prefab in {info.ResourcePath}");
                return null;
            }

            controller.InitScreen();
            return controller;
        }
    }
}
