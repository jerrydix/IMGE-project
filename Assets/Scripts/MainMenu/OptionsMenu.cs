using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Slider volumeSlider;
    private Toggle fullscreenToggle;
    [SerializeField] private AudioMixer mixer;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameManager.Instance.ChangeVolume(Mathf.Log10(volume) * 20);
    }

    public void SetFullscreen(bool fullscreened)
    {
        Screen.fullScreen = fullscreened;
    }
}
