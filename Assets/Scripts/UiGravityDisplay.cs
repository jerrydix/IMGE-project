using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    TextMeshProUGUI objectGravity;

    private void Start()
    {
        objectGravity = this.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        objectGravity.SetText((-(gun.GetComponent<PlayerShooting>().gravity / 9.81 )).ToString("0.00") + "g");
    }
}
