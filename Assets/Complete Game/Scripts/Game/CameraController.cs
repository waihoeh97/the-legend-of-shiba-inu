using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
//	public Transform firstWallX;
//	public Transform lastWallX;
//	public Transform firstWallY;
//	public Transform lastWallY;

	float minX;
	float maxX;
	float minY;
	float maxY;
	private Vector3 offset;
	private static CameraController _instance;
	public static CameraController Instance { get{return _instance;}}

	bool cutsceneOverride = false;
	public bool Movement = false;

	// Use this for initialization
	void Awake ()
	{
		if ( _instance == null ) _instance = this;
		else if ( _instance != this ) Destroy(this);

//		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Transform>();
	}
	void Start () {
		offset = transform.position - player.transform.position;
//		minX = firstWallX.transform.position.x + 2f;
//		maxX = lastWallX.transform.position.x - 2f;
//		minY = firstWallY.transform.position.y + 2f;
//		maxY = lastWallY.transform.position.y - 2f;
	}

	// Update is called after Update each frame
	void LateUpdate () {
		if ( cutsceneOverride == false ) transform.position = player.transform.position + offset;
	}

	public IEnumerator CutsceneRoutine ( Transform target, Transform origin ) {

		cutsceneOverride = true;
		Movement = true;
		Vector3 newTarget = target.position;
		newTarget.z = -10f;


		while( Vector3.Distance(this.transform.position, newTarget) > 0.1f ) {
			yield return null;
			this.transform.position = Vector3.MoveTowards( this.transform.position, newTarget, Time.deltaTime * 8f ) ;
		}

		yield return new WaitForSeconds( 2f);

		while( Vector3.Distance(this.transform.position, origin.position + new Vector3(0f,0f,-10f) ) > 0.1f) {
			yield return null;
			this.transform.position = Vector3.MoveTowards( this.transform.position, origin.position + new Vector3(0f,0f,-10f), Time.deltaTime * 8f ) ;
		}

		cutsceneOverride = false;
		Movement = false;
	}
}
