using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public enum Sounds
    {
        TurretShoot,
        Jump,
        GunShoot,
        HatchOpen,
        HatchClose,
        Damage,
        Heal,
        //...
    }
    public static SoundManager Instance { get; set; }
    private AudioSource source;
    public AudioClip[] audioClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
        //mixer.SetFloat("Volume", GameManager.Instance.currentVolume);
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.TurretShoot:
                source.volume = 0.1f;
                source.PlayOneShot(audioClips[0]); break;
            case Sounds.Jump:
                source.PlayOneShot(audioClips[1]); break;
            case Sounds.GunShoot:
                source.PlayOneShot(audioClips[2]); break;
            case Sounds.HatchOpen:
                source.PlayOneShot(audioClips[3]); break;
            case Sounds.HatchClose:
                source.PlayOneShot(audioClips[4]); break;
            case Sounds.Damage:
            //{ source.PlayOneShot(audioClips[2]); break; }
            case Sounds.Heal: break;
            //{ source.PlayOneShot(audioClips[3]); break; }
            //...
            default:
                source.volume = 1f; break;
        }
    }
}
