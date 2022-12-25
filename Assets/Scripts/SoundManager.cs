using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    private AudioSource source;

    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
        mixer.SetFloat("Volume", GameManager.Instance.currentVolume);
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
