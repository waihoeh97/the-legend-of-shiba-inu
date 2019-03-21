using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {
	public Transform origin;
	public Transform target;

	public void TriggerCutscene() {
		CameraController.Instance.StartCoroutine( CameraController.Instance.CutsceneRoutine( this.target, this.origin) );
	}
}
