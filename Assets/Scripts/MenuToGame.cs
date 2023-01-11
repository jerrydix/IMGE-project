using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuToGame : MonoBehaviour
{
    public void LoadLevel(string _levelName)
    {
        StartCoroutine(LoadingAsync(_levelName));
    }

    IEnumerator LoadingAsync (string _levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_levelName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }
    }
}
