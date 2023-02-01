using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [HideInInspector] public float currentVolume;
    [HideInInspector] public float currentSensitivity;
    [HideInInspector] public bool sucExtrLevel1;
    [HideInInspector] public bool sucExtrLevel2;
    [HideInInspector] public bool sucExtrLevel3;
    //[HideInInspector] public bool sucExtrLevel4;

    private GameObject _genPart1;
    private GameObject _genPart2;
    private GameObject _genPart3;
    //private GameObject _genPart4;
    private LevelFinish _levelFinish;

    public int genCounter = 0; 

    [HideInInspector] public bool playTutorial;

    private bool level1Done, level2Done, level3Done;// level4Done;

    private void Awake()
    {
        playTutorial = true;
        currentVolume = 1;
        currentSensitivity = 15;
        DontDestroyOnLoad(this);
        sucExtrLevel1 = false;
        sucExtrLevel2 = false;
        sucExtrLevel3 = false;
        //sucExtrLevel4 = false;

        level1Done = false;
        level2Done = false;
        level3Done = false;
        //level4Done = false;
        
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 0 && index != 1)
        {
            _levelFinish = GameObject.Find("LevelFinish").GetComponent<LevelFinish>();
        }

        if (index == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            _genPart1 = GameObject.Find("GenPart1");
            _genPart2 = GameObject.Find("GenPart2");
            _genPart3 = GameObject.Find("GenPart3");
            //_genPart4 = GameObject.Find("GenPart4");
        }
        
        if (index == 0)
        {
            if (sucExtrLevel1 || level1Done) 
            {
                _genPart1.transform.Find("Model").gameObject.SetActive(true);
                if (!level1Done)
                {
                    genCounter++;
                    level1Done = true;
                }
            }
            if (sucExtrLevel2 || level2Done)
            {
                _genPart2.transform.Find("Model").gameObject.SetActive(true);
                if (!level2Done)
                {
                    genCounter++;
                    level2Done = true;
                }
            }
            if (sucExtrLevel3 || level3Done)
            {
                _genPart3.transform.Find("Model").gameObject.SetActive(true);
                if (!level3Done)
                {
                    genCounter++;
                    level3Done = true;
                }
            }
            /*if (sucExtrLevel4 || level4Done)
            {
                _genPart4.transform.Find("Model").gameObject.SetActive(true);
                if (!level4Done)
                {
                    genCounter++;
                    level4Done = true;
                }
            }*/
        }
    }

    private void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 0 && index != 1)
        {
            if (_levelFinish.finished && _levelFinish.successful)
            {
                switch (index)
                {
                    case 2: sucExtrLevel1 = true; break;
                    case 3: sucExtrLevel2 = true; break; 
                    case 4: sucExtrLevel3 = true; break; 
                    //case 5: sucExtrLevel4 = true; break; 
                }    
            }
        }

        /*if (index == 0)
        {
            if (sucExtrLevel1) 
            {
                _genPart1.transform.Find("Model").gameObject.SetActive(true);
            }
            if (sucExtrLevel2)
            {
                _genPart2.transform.Find("Model").gameObject.SetActive(true);
            }
            if (sucExtrLevel3)
            {
                _genPart3.transform.Find("Model").gameObject.SetActive(true);
            }
            if (sucExtrLevel4)
            {
                _genPart4.transform.Find("Model").gameObject.SetActive(true);
            }
        }*/
    }

    public void TutorialSwitcher(bool active)
    {
        playTutorial = active;
    }
    
}
