using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().isOn = GameManager.Instance.playTutorial;
    }

    public void Switch(bool on)
    {
        GameManager.Instance.TutorialSwitcher(on);
    }
    
    
}
