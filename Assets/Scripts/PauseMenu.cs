using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool active;
    private bool fullscreened;

    private void Start()
    {
        active = false;
        fullscreened = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !active)
        {
            pauseMenu.SetActive(true);
            active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && active)
        {
            pauseMenu.SetActive(false);
            active = false;
        }
    }

    public void Fullscreen()
    {
        if (!fullscreened)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        } else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
