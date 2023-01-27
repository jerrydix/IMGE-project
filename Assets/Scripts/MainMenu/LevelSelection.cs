using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void Load0()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade(false, 0);
    }
    
    public void Load1()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade(false, 1);
    }
    
    public void Load2()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade(false, 2);
    }
    
    public void Load3()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade(false, 3);
    }
    
    public void Load4()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade(false, 4);
    }
    
    /*private void LoadLevel(int sceneIndex)
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
    }*/
    
}

