using UnityEngine;
using UnityEngine.UI;
 
[RequireComponent(typeof(Slider))]
public class SliderSwitcher : MonoBehaviour
{
    private Slider _slider;
    private UiManager _manager;
    private float center = 0f;

    void Start() {
        _slider = GetComponent<Slider>();
        _manager = GetComponent<UiManager>();
    }
 
    void Update() {
        //print("test");
       _slider.fillRect.anchorMin = new Vector2(Mathf.Clamp(_slider.handleRect.anchorMin.x, -4.905f, center), 0); 
       _slider.fillRect.anchorMax = new Vector2(Mathf.Clamp(_slider.handleRect.anchorMin.x, center, 4.905f), 1);
       print(_slider.fillRect.anchorMin);
       print(_slider.fillRect.anchorMax);
    }
}