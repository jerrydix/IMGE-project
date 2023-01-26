using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool active;
    private bool fullscreened;
    
    private PlayerInput inputActions;

    [SerializeField] private AudioMixer mixer;
    
    [SerializeField] private Slider volSlider;
    [SerializeField] private Slider sensSlider;
    private float _vol;
    private float _sens;

    private void Awake()
    {
        active = false;
        fullscreened = true;
    }

    private void Escape(InputAction.CallbackContext context)
    {
        if (!active)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            pauseMenu.SetActive(true);
            active = true;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            active = false;
            Time.timeScale = 1;
        }
    }
    
    private void Start()
    {
        inputActions = GameObject.Find("Player").GetComponent<PlayerMovement>().inputActions;
        inputActions.UI.Enable();
        inputActions.UI.Escape.performed += Escape;
        _vol = GameManager.Instance.currentVolume;
        _sens = GameManager.Instance.currentSensitivity;
        volSlider.value = _vol;
        sensSlider.value = _sens;
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
        GameObject.Find("Main Camera").GetComponent<CameraMove>().xSensi = sensi;
        GameObject.Find("Main Camera").GetComponent<CameraMove>().ySensi = sensi;
        GameManager.Instance.currentSensitivity = sensi;
    }
    
    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameManager.Instance.currentVolume = volume;
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
