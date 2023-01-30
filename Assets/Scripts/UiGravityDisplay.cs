using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    //TextMeshProUGUI objectGravity;
    [HideInInspector] public float minVal;
    private Slider _slider;
    [SerializeField] private bool inverted;

    private void Start()
    {
       
        _slider = GetComponent<Slider>();
        _slider.maxValue = -gun.GetComponent<PlayerShooting>()._force[0];
       
    }

    void Update()
    {
        if (inverted && gun.GetComponent<PlayerShooting>().currentForce > 0)
        {
            _slider.value = gun.GetComponent<PlayerShooting>().currentForce;
        }
        else if (!inverted && gun.GetComponent<PlayerShooting>().currentForce < 0)
        {
            _slider.value = -gun.GetComponent<PlayerShooting>().currentForce;
        }
        else
        {
            _slider.value = 0;
        }
        
        
        //print(gun.GetComponent<PlayerShooting>().currentForce);
        //_slider.value = gun.GetComponent<PlayerShooting>().currentForce;
        //objectGravity.SetText((-(gun.GetComponent<PlayerShooting>().currentForce )).ToString("0.00") + "g");
    }
}
