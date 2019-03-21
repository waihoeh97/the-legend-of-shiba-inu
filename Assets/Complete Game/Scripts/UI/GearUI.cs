using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearUI : MonoBehaviour {

	public PlayerInventory gearCount;
	public Text gear;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gear.text = gearCount.gearCount.ToString();
	}
}
