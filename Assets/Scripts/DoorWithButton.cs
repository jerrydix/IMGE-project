using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithButton : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
        }
        else
        {
            _animator.SetBool("Open", false);
        }
    }
}
