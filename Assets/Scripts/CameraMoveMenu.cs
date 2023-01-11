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
    [SerializeField] private Transform cam;
    [SerializeField] private float positionTurnSpeed;
    [SerializeField] private float rotationTurnSpeed;
    private bool _inCredits;
    private bool _inOptions;
    private bool _inQuit;

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }

    private void Awake()
    {
        _inCredits = false;
        _inOptions = false;
        _inQuit = false;
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

    public void Return()
    {
        _inCredits = false;
        _inOptions = false;
        _inQuit = false;
    }
    
    private void Update()
    {
        if (_inQuit)
        {
            //cam.position = defaultTransform.position;
            //cam.rotation = defaultTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, quitTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(quitTransform.rotation.eulerAngles), rotationTurnSpeed);
        }
        else if (_inOptions)
        {
            //cam.position = creditsTransform.position;
            //cam.rotation = creditsTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, optionsTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(optionsTransform.rotation.eulerAngles), rotationTurnSpeed);
        }
        else if (_inCredits)
        {
            //cam.position = creditsTransform.position;
            //cam.rotation = creditsTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, creditsTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(creditsTransform.rotation.eulerAngles), rotationTurnSpeed);

        }
        else
        {
            //cam.position = defaultTransform.position;
            //cam.rotation = defaultTransform.rotation;
            cam.position = Vector3.Lerp(cam.position, defaultTransform.position, positionTurnSpeed);
            cam.rotation = Quaternion.Lerp(Quaternion.Euler(cam.rotation.eulerAngles), Quaternion.Euler(defaultTransform.rotation.eulerAngles), rotationTurnSpeed);
        }
    }
}
