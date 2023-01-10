using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool floating = false;
    private bool antiGravityBool = false;
    private ConstantForce constantForce;
    private bool modifying;

    private void Start()
    {
        constantForce = GetComponent<ConstantForce>();
        constantForce.enabled = false;
    }
    public void ChangeGravity()
    {
        if (!modifying)
        {
            modifying = true;
            antiGravityBool = true;
            constantForce.enabled = antiGravityBool;
        }
        else if (modifying)
        {
            modifying = false;
            antiGravityBool = false;
            constantForce.enabled = antiGravityBool;
        }
    }
}
