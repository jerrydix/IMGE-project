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
            yield return null;
        }
    }
}
