using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMasterVolume : MonoBehaviour {
	public Slider bgmSlider;

	// Use this for initialization
	void Start () {
		bgmSlider.value = OptionsSaver.Instance.masterVolume;
	}
	
	// Update is called once per frame
	void Update () {
		SoundManagerScript.Instance.bgmAudioSource.volume = bgmSlider.value;
		OptionsSaver.Instance.masterVolume = bgmSlider.value;

	}
}
