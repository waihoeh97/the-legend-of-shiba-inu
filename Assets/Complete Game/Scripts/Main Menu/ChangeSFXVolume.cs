using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSFXVolume : MonoBehaviour {
	public Slider sfxSlider;

	// Use this for initialization
	void Start () {
		sfxSlider.value = OptionsSaver.Instance.sfxVolume;
	}
	
	// Update is called once per frame
	void Update () {
		SoundManagerScript.Instance.sfxAudioSource.volume = sfxSlider.value;
		OptionsSaver.Instance.sfxVolume = sfxSlider.value;
	}
}
