using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBrightness : MonoBehaviour {
	public Slider brightnessSlider;

	// Use this for initialization
	void Start () {
		brightnessSlider =GetComponent<Slider>();
		brightnessSlider.value = OptionsSaver.Instance.brightness;

	}
	
	// Update is called once per frame
	void Update () {
		OptionsSaver.Instance.brightness = brightnessSlider.value;
		OptionsSaver.Instance.UpdateSetting();
	}
		
}
