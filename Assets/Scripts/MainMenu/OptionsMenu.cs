using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Toggle fullscreenToggle;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider volSlider;
    [SerializeField] private Slider sensSlider;
    private float _vol;
    private float _sens;

    private void Start()
    {
        _vol = GameManager.Instance.currentVolume;
        _sens = GameManager.Instance.currentSensitivity;
        volSlider.value = _vol;
        sensSlider.value = _sens;
    }
    

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameManager.Instance.currentVolume = volume;
    }
    
    public void SetSensitivity(float sensi)
    {
        GameObject.Find("Main Camera").GetComponent<CameraMove>().xSensi = sensi;
        GameObject.Find("Main Camera").GetComponent<CameraMove>().ySensi = sensi;
        GameManager.Instance.currentSensitivity = sensi;
    }

    public void SetFullscreen(bool fullscreened)
    {
        Screen.fullScreen = fullscreened;
    }
}
