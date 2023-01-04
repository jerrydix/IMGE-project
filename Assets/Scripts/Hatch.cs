using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _anim.SetBool("Open", true);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _anim.SetBool("Open", false);
        }
    }
}
