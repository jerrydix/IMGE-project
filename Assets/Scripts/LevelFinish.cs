using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private ItemPickup genPart;
    [HideInInspector] public bool finished;
    [HideInInspector] public bool successful;

    private void Awake()
    {
        finished = false;
        successful = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && genPart.equipped)
        {
            finished = true;
            successful = true;
        } 
        else if (other.CompareTag("Player") && !genPart.equipped)
        {
            finished = true;
            successful = false;
        }
    }
}
