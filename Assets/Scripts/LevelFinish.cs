using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private ItemPickup genPart;
    public bool finished;

    private void Awake()
    {
        finished = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && genPart.equipped)
        {
            finished = true;
        }
    }
}
