using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool floating = false;
    private bool antiGravityBool = false;
    [SerializeField] private float antiGravForce;
    private ConstantForce constantForce;
    private Rigidbody rigidbody;

    private void Start()
    {
        constantForce = GetComponent<ConstantForce>();
        rigidbody = GetComponent<Rigidbody>();
        constantForce.enabled = false;
    }

    public void ChangeGravity()
    {
        if (!floating && !antiGravityBool)
        {
            floating = true;
            rigidbody.useGravity = false;
        }
        else if (floating && !antiGravityBool)
        {
            floating = false;
            antiGravityBool = true;
            rigidbody.useGravity = true;
            constantForce.enabled = antiGravityBool;
        }
        else if (!floating && antiGravityBool)
        {
            antiGravityBool = false;
            constantForce.enabled = antiGravityBool;
        }
    }
}
