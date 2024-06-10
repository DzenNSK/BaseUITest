using System;
using UnityEngine;

namespace BaseUITest
{
    public class ScreenInfo
    {
        private readonly Type controllerType;
        private readonly string resourcePath;
        private GameObject instance;

        private GameObject prefab;
        private ResourceRequest request;

        public Type ControllerType => controllerType;
        public string ResourcePath => resourcePath;

        public ScreenInfo(Type type, string resourcePath)
        {
            this.controllerType = type;
            this.resourcePath = resourcePath;
        }

        public GameObject GetInstance(Transform parent)
        {
            if (instance != null) return instance;

            if (prefab == null) prefab = LoadPrefab();

            instance = GameObject.Instantiate(prefab, parent);
            return instance;
        }

        public GameObject LoadPrefab()
        {
            if (request == null)
            {
                var obj = Resources.Load(resourcePath);
                prefab = obj as GameObject;
            }

            return prefab;
        }

    }
}
