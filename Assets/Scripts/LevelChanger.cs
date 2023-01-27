using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private LevelFinish _levelFinish;
    private float _index;
    [SerializeField] private Animator anim;
    void Start()
    {
        _index = SceneManager.GetActiveScene().buildIndex;
        if (_index != 0 && _index != 1)
        {
            _levelFinish = GameObject.Find("LevelFinish").GetComponent<LevelFinish>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_index != 0 && _index != 1 && _index != -1 && _levelFinish.finished)
        {
            Fade(true, 0);
        }
    }

    public void Fade(bool normal, int index)
    {
        if (!normal)
        {
            _index = index;
        }
        anim.SetTrigger("FadeOut");
    }
    public void FadeComplete()
    {
        switch (_index)
        {
            case -1: SceneManager.LoadScene(0); break;
            case 0: SceneManager.LoadScene(1); break;
            case 1: SceneManager.LoadScene(2); break;
            case 2: SceneManager.LoadScene(3); break;
            case 3: SceneManager.LoadScene(4); break;
            case 4: SceneManager.LoadScene(5); break;
            case 5: SceneManager.LoadScene(0); break;
        }
    }
}
