using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void Load1()
    {
        LoadLevel(2);
    }
    
    public void Load2()
    {
        LoadLevel(3);
    }
    
    public void Load3()
    {
        LoadLevel(4);
    }
    
    public void Load4()
    {
        LoadLevel(5);
    }
    
    private void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadingAsync(sceneIndex));
    }

    IEnumerator LoadingAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
    
}

