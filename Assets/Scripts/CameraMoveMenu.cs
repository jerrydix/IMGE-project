using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveMenu : MonoBehaviour
{
    [SerializeField] private Transform creditsTransform;
    [SerializeField] private Transform optionsTransform;
    [SerializeField] private Transform defaultTransform;
    [SerializeField] private Transform cam;
    [SerializeField] private float positionTurnSpeed;
    [SerializeField] private float rotationTurnSpeed;
    private bool _inCredits;
    private bool _inOptions;

    private void Awake()
    {
        _inCredits = false;
        _inOptions = false;
    }

    public void CreditsMenu()
    {
        _inCredits = true;
    }

    public void OptionsMenu()
    {
        _inOptions = true;
    }

    public void Return()
    {
        _inCredits = false;
        _inOptions = false;
    }
    
    private void Update()
    {
        if (!_inCredits && !_inOptions)
        {
            //cam.position = defaultTransform.position;
            //cam.rotation = defaultTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, defaultTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(defaultTransform.rotation.eulerAngles), rotationTurnSpeed);
        }
        else if (!_inOptions && _inCredits)
        {
            //cam.position = creditsTransform.position;
            //cam.rotation = creditsTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, optionsTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(optionsTransform.rotation.eulerAngles), rotationTurnSpeed);
        } else
        {
            //cam.position = creditsTransform.position;
            //cam.rotation = creditsTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, creditsTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(creditsTransform.rotation.eulerAngles), rotationTurnSpeed);

        }
    }
}
