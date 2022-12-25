using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public enum Sounds
    {
        Damage,
        Heal,
        //...
    }
    public static SoundManager Instance { get; set; }
    private AudioSource source;
    [SerializeField] private AudioClip[] audioClips;

    [SerializeField] private AudioMixer mixer;

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
            case Sounds.Damage:
            //{ source.PlayOneShot(audioClips[0]); break; }
            case Sounds.Heal: break;
            //{ source.PlayOneShot(audioClips[1]); break; }
            //...
        }
    }
}
