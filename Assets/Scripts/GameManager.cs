using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public float currentVolume;

    private void Awake()
    {
        currentVolume = 100;
    }

    private void Update()
    {
        
    }
}
