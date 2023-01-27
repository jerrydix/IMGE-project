using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAudio : MonoBehaviour
{

    private AudioSource _source;
    [SerializeField] private AudioClip audioTrack;
    // Start is called before the first frame update
    void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = audioTrack;
        _source.Play();
    }
}
