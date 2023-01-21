using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithButton : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private AudioSource _source;
    
    private Animator _animator;

    private bool _closed;

    private void Awake()
    {
        _closed = true;
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        bool allPressed = true;
        
        foreach (var button in buttons)
        {
            if (button.pressed == 0)
            {
                allPressed = false;
                break;
            }
        }

        if (allPressed)
        {
            _animator.SetBool("Open", true);
            if (_closed)
            {
                PlayOpen();
                _closed = false;
            }
        }
        else
        {
            _animator.SetBool("Open", false);
            if (!_closed)
            {
                PlayClose();
                _closed = true;
            }
        }
    }

    private void PlayOpen()
    {
        _source.PlayOneShot(SoundManager.Instance.audioClips[3]);
    }
    private void PlayClose()
    {
        _source.PlayOneShot(SoundManager.Instance.audioClips[4]);
    }
    
}
