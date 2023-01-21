using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class VFXController : MonoBehaviour
{

    public List<GameObject> topic = new List<GameObject>();
    public List<GameObject> allEffectsInTopic = new List<GameObject>();
    public GameObject selectedVfx, selectedTopic;
    public int currSelectedArea, currSelectChild;
    public TextMeshProUGUI vfxNameText;
    [SerializeField]
    public CameraInfo[] cI;
    public Camera cam;

    [Serializable]
    public struct CameraInfo
    {
        public Transform targetTransform;
        public string tagName;
    }
    
    public void SetCameraToTopicPosition()
    {
        foreach(CameraInfo camInfo in cI)
        {
            if (camInfo.tagName.Equals(selectedTopic.tag))
            {
                cam.transform.position = camInfo.targetTransform.position;
                cam.transform.rotation = camInfo.targetTransform.rotation;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ActivateArea();
        
    }

    void ActivateArea()
    {
        topic.ForEach(e =>
        {
            if (topic.IndexOf(e) == currSelectedArea)
            {
                selectedTopic = e;
                e.SetActive(true);
                currSelectChild = 0;
                ActivateVFX(AllInTopic());
                SetCameraToTopicPosition();
            }
            else
            {
                e.SetActive(false);
            }

        });
    }

    List<GameObject> AllInTopic()
    {
        allEffectsInTopic.Clear();
        foreach (Transform i in selectedTopic.transform)
        {
            allEffectsInTopic.Add(i.gameObject);
        }
        return allEffectsInTopic;
    }

    void ActivateVFX(List<GameObject> vfxInTopic)
    {
        vfxInTopic.ForEach(e =>
        {
            if (vfxInTopic.IndexOf(e) == currSelectChild)
            {
                selectedVfx = e;
                e.SetActive(true);
            }
            else
            {
                e.SetActive(false);
            }
        });
        SetText();
    }

    void ChangeArea(bool goingForward)
    {
        if (!goingForward)
        {
            if (currSelectedArea > 0)
            {
                currSelectedArea--;
            }
            else
            {
                currSelectedArea = topic.Count - 1;
            }
        }
        else
        {
            if (currSelectedArea < topic.Count - 1)
            {
                currSelectedArea++;
            }
            else
            {
                currSelectedArea = 0;
            }
        }
        ActivateArea();

    }

    void ChangeVFX(bool goingForward)
    {
        if (!goingForward)
        {
            if (currSelectChild > 0)
            {
                currSelectChild--;
            }
            else
            {
                currSelectChild = allEffectsInTopic.Count - 1;
            }
        }
        else
        {
            if (currSelectChild < allEffectsInTopic.Count - 1)
            {
                currSelectChild++;
            }
            else
            {
                currSelectChild = 0;
            }
        }
        ActivateVFX(AllInTopic());
        SetText();
    }


    void SetText()
    {
        if (vfxNameText != null)
        {
            if (selectedVfx != null)
            {
                vfxNameText.text = $"Topics: {selectedTopic.name }" + "\n" + $"VFX Name: {selectedVfx.name}";
            }
            else
            {
                vfxNameText.text = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeVFX(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            ChangeVFX(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeArea(false);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeArea(true);
        }
    }
}
