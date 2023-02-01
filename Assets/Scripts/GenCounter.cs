using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI levelSelectText;
    private int _counter;
    
    void Start()
    {
        _counter = GameManager.Instance.genCounter;
        mainText.text = _counter + "/ 3 generator parts collected";
        levelSelectText.text = _counter + "/ 3 generator parts collected";
    }

    // Update is called once per frame
    void Update()
    {
        _counter = GameManager.Instance.genCounter;
        mainText.text = _counter + "/ 3 generator parts collected";
        levelSelectText.text = _counter + "/ 3 generator parts collected";
    }
}
