using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaseUITest
{
    public class ScreenLoading : UIScreenBase
    {
        private string sceneToLoad;
        private AsyncOperation request;

        public void ReloadScene(string sceneName)
        {
            onAnimationComplete += LoadScene;
            sceneToLoad = sceneName;
            Show();
        }

        private void LoadScene()
        {
            onAnimationComplete -= LoadScene;
            request = SceneManager.LoadSceneAsync(sceneToLoad);
            StartCoroutine("AwaitSceneLoading");
        }

        private IEnumerator AwaitSceneLoading()
        {
            if (request == null)
            {
                Debug.LogError("No loading request");
                yield break;
            }

            while (!request.isDone)
            {
                yield return null;
            }

            Hide();
        }
    }
}
