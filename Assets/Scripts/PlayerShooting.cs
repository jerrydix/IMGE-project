using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [FormerlySerializedAs("FPSCamera")] public Camera fpsCamera; 
    
    private void Start()
    {
        input = new PlayerInput();
        input.Moving.Enable();
        input.Moving.Fire.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, 100))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.ChangeGravity();
                }
            }
        }
    }
}