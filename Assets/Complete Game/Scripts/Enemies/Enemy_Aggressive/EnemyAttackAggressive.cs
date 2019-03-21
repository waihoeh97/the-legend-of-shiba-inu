using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAggressive : MonoBehaviour {

	EnemyBehaviourAggressive enemyAI;

	public float shootDelay;
	private float lastShoot;

	public GameObject bullet;
	public GameObject InstantiatedObj;

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		enemyAI = gameObject.GetComponent<EnemyBehaviourAggressive>();
	}

	public IEnumerator isShoot ()
	{
		yield return null;

		if (Time.time > shootDelay + lastShoot)
		{
			if (enemyAI.curVelocity.y > 0)
			{
				Debug.Log("Is Shooting Up");
				anim.SetBool("isAttackUp", true);
				anim.SetBool("isAttackDown", false);
				anim.SetBool("isAttackLeft", false);
				anim.SetBool("isAttackRight", false);
			}
			else if (enemyAI.curVelocity.y < 0)
			{
				Debug.Log("Is Shooting Down");
				anim.SetBool("isAttackUp", false);
				anim.SetBool("isAttackDown", true);
				anim.SetBool("isAttackLeft", false);
				anim.SetBool("isAttackRight", false);
			}
			else if (enemyAI.curVelocity.x < 0)
			{
				Debug.Log("Is Shooting Left");
				anim.SetBool("isAttackUp", false);
				anim.SetBool("isAttackDown", false);
				anim.SetBool("isAttackLeft", true);
				anim.SetBool("isAttackRight", false);
			}
			else if (enemyAI.curVelocity.x > 0)
			{
				Debug.Log("Is Shooting Right");
				anim.SetBool("isAttackUp", false);
				anim.SetBool("isAttackDown", false);
				anim.SetBool("isAttackLeft", false);
				anim.SetBool("isAttackRight", true);
			}	

			yield return new WaitForSeconds(0.5f);
			anim.SetBool("isAttackUp", false);
			anim.SetBool("isAttackDown", false);
			anim.SetBool("isAttackLeft", false);
			anim.SetBool("isAttackRight", false);
			lastShoot = Time.time;
		}
	}

	public void Shoot ()
	{
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_ENEMYATTACK);
		InstantiatedObj = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
