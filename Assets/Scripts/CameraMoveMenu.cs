using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMoveMenu : MonoBehaviour
{
    [SerializeField] private Transform creditsTransform;
    [SerializeField] private Transform optionsTransform;
    [SerializeField] private Transform quitTransform;
    [SerializeField] private Transform defaultTransform;
    [SerializeField] private Transform levelsTransform;
    [SerializeField] private Transform cam;
    [SerializeField] private float positionTurnSpeed;
    [SerializeField] private float rotationTurnSpeed;
    private bool _inCredits;
    private bool _inOptions;
    private bool _inQuit;
    private bool _inLevels;

    private void Start()
    {
        _inCredits = false;
        _inOptions = false;
        _inQuit = false;
        _inLevels = false;
    }

    public void CreditsMenu()
    {
        _inCredits = true;
    }

    public void OptionsMenu()
    {
        _inOptions = true;
    }

    public void QuitMenu()
    {
        _inQuit = true;
    }

    public void LevelSelection()
    {
        _inLevels = true;
    }

    public void Return()
    {
        _inCredits = false;
        _inOptions = false;
        _inQuit = false;
        _inLevels = false;
    }

    private void Update()
    {
        if (_inQuit)
        {
            cam.position = Vector3.Lerp(cam.position, quitTransform.position, positionTurnSpeed * Time.deltaTime);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(quitTransform.rotation.eulerAngles), rotationTurnSpeed * Time.deltaTime);
        }
        else if (_inOptions)
        {
            cam.position = Vector3.Lerp(cam.position, optionsTransform.position, positionTurnSpeed * Time.deltaTime);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(optionsTransform.rotation.eulerAngles), rotationTurnSpeed * Time.deltaTime);
        }
        else if (_inCredits)
        {
            cam.position = Vector3.Lerp(cam.position, creditsTransform.position, positionTurnSpeed * Time.deltaTime);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(creditsTransform.rotation.eulerAngles), rotationTurnSpeed * Time.deltaTime);
        }
        else if (_inLevels)
        {
            cam.position = Vector3.Lerp(cam.position, levelsTransform.position, positionTurnSpeed * Time.deltaTime);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(levelsTransform.rotation.eulerAngles), rotationTurnSpeed * Time.deltaTime);
        }
        else
        {
            cam.position = Vector3.Lerp(cam.position, defaultTransform.position, positionTurnSpeed * Time.deltaTime);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(defaultTransform.rotation.eulerAngles), rotationTurnSpeed * Time.deltaTime);
        }
    }
}
