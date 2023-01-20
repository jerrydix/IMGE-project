using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [HideInInspector] public float currentVolume;
    [HideInInspector] public bool sucExtrLevel1;
    [HideInInspector] public bool sucExtrLevel2;
    [HideInInspector] public bool sucExtrLevel3;
    [HideInInspector] public bool sucExtrLevel4;
    private bool currentFinished;
    private bool currentSuccessful;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        sucExtrLevel1 = false;
        sucExtrLevel2 = false;
        sucExtrLevel3 = false;
        sucExtrLevel4 = false;
        currentVolume = 100;
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            currentFinished = GameObject.Find("LevelFinish").GetComponent<LevelFinish>().finished;
            currentSuccessful = GameObject.Find("LevelFinish").GetComponent<LevelFinish>().successful;
        }
    }

    private void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (currentFinished)
        {
            switch (index)
            {
                case 2: SceneManager.LoadScene(3); break;
                case 3: SceneManager.LoadScene(4); break;
                case 4: SceneManager.LoadScene(5); break;
                case 5: SceneManager.LoadScene(0); break;
            }
        }

        if (currentFinished && currentSuccessful)
        {
            switch (index)
            {
                case 2: sucExtrLevel1 = true; break;
                case 3: sucExtrLevel1 = true; break; 
                case 4: sucExtrLevel1 = true; break; 
                case 5: sucExtrLevel1 = true; break; 
            }    
        }
    }
    
    public void ChangeVolume(float volume)
    {
        currentVolume = volume;
    }
}
