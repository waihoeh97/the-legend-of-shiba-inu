using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropertiesAggressive : MonoBehaviour {

	public int health;

	EnemyBehaviourAggressive enemyAI;
	PlayerProperties player;
//	CameraShake cameraProperties;

	Animator anim;

	void Awake ()
	{
		enemyAI = gameObject.GetComponent<EnemyBehaviourAggressive>();
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		player = go.GetComponent<PlayerProperties>();
	}

	// Use this for initialization
	void Start ()
	{
		//		cameraProperties = FindObjectOfType<CameraShake>();
		anim = GetComponent<Animator>();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
	}

	IEnumerator AttackEffectDelay ()
	{
		yield return null;

		if(enemyAI.curVelocity.x > 0)
		{
			//transform.Translate(Vector3.left);
			GetComponent<EnemyAttackAggressive>().enabled = false;
			enemyAI.currentSpeed = 0;

			anim.SetBool("isHitUp", false);
			anim.SetBool("isHitDown", false);
			anim.SetBool("isHitLeft", false);
			anim.SetBool("isHitRight", true);
		}
		else if(enemyAI.curVelocity.y > 0)
		{
			//transform.Translate(Vector3.down);
			GetComponent<EnemyAttackAggressive>().enabled = false;
			enemyAI.currentSpeed = 0;

			anim.SetBool("isHitUp", true);
			anim.SetBool("isHitDown", false);
			anim.SetBool("isHitLeft", false);
			anim.SetBool("isHitRight", false);
		}
		else if(enemyAI.curVelocity.x < 0)
		{
			//transform.Translate(Vector3.right);
			GetComponent<EnemyAttackAggressive>().enabled = false;
			enemyAI.currentSpeed = 0;

			anim.SetBool("isHitUp", false);
			anim.SetBool("isHitDown", false);
			anim.SetBool("isHitLeft", true);
			anim.SetBool("isHitRight", false);
		}
		else if(enemyAI.curVelocity.x < 0)
		{
			//transform.Translate(Vector3.up);
			GetComponent<EnemyAttackAggressive>().enabled = false;
			enemyAI.currentSpeed = 0;

			anim.SetBool("isHitUp", false);
			anim.SetBool("isHitDown", true);
			anim.SetBool("isHitLeft", false);
			anim.SetBool("isHitRight", false);
		}
		TakeDamage(1);

		yield return new WaitForSeconds(0.5f);

		GetComponent<EnemyBehaviourAggressive>().enabled = true;
		enemyAI.currentSpeed = enemyAI.speed;

		anim.SetBool("isHitUp", false);
		anim.SetBool("isHitDown", false);
		anim.SetBool("isHitLeft", false);
		anim.SetBool("isHitRight", false);
	}

	void DeathSound ()
	{
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_ENEMYDEATH);
	}

	void DeathProperties ()
	{
		SpawnManager.Instance.SpawnGear(this.transform.position,10);
		Destroy(gameObject);
	}

	void Death ()
	{
		if(health <= 0)
		{
			GetComponent<EnemyAttackAggressive>().enabled = false;
			enemyAI.currentSpeed = 0;

			anim.SetBool("isHitUp", false);
			anim.SetBool("isHitDown", false);
			anim.SetBool("isHitLeft", false);
			anim.SetBool("isHitRight", false);
			anim.SetBool("Death", true);
			//cameraProperties.Shake(0.1f, 0.1f);
		}
	}

	IEnumerator OnPlayerDeath ()
	{
		yield return null;
		if (player.currentHealth <= 0)
		{
			yield return new WaitForSeconds (2.0f);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		anim.SetFloat("speed", enemyAI.currentSpeed);
		Death();
		StartCoroutine(OnPlayerDeath());
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.CompareTag("PlayerCombo")) 
		{
			StartCoroutine(AttackEffectDelay());
		}
		else
		{
			enemyAI.randNum = Random.Range(1, 5);
		}
	}
}
