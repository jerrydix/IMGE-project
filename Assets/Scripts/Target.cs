using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool floating = false;
    private bool antigravitybool = false;
    [SerializeField] private float antiGravForce;
    private ConstantForce constantForce;
    private Rigidbody rigidbody;

    private void Start()
    {
        constantForce = GetComponent<ConstantForce>();
        rigidbody = GetComponent<Rigidbody>();
        constantForce.enabled = false;
    }

    public void changeGravity()
    {
        if (!floating && !antigravitybool)
        {
            floating = true;
            rigidbody.useGravity = false;
        }
        else if (floating && !antigravitybool)
        {
            floating = false;
            antigravitybool = true;
            rigidbody.useGravity = true;
            constantForce.enabled = antigravitybool;
        }
        else if (!floating && antigravitybool)
        {
            antigravitybool = false;
            constantForce.enabled = antigravitybool;
        }
        
        
    }
}
