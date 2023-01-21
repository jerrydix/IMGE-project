using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool active;
    private bool fullscreened;
    
    private PlayerInput inputActions;

    [SerializeField] private AudioMixer mixer;
    private void Awake()
    {
        inputActions = new PlayerInput();
        inputActions.UI.Enable();
        inputActions.UI.Escape.performed += Escape;
        active = false;
    }

    private void Escape(InputAction.CallbackContext context)
    {
        if (!active)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            pauseMenu.SetActive(true);
            active = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            active = false;
        }
    }
    
    private void Start()
    {
        fullscreened = true;
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

    public void SetSensitivity(float sensi)
    {
        GameObject.Find("CameraHolder").GetComponent<CameraMove>().xSensi = sensi;
        GameObject.Find("CameraHolder").GetComponent<CameraMove>().ySensi = sensi;
    }
    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameManager.Instance.ChangeVolume(Mathf.Log10(volume) * 20);
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
