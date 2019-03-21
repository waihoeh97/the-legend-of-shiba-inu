using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour {

	int randomDeathDirection;

	public int startingHealth = 3;
	public int currentHealth;
	public List<GameObject> hpImages;
	public GameObject hpImage;

	public GameObject spawnPoint;
	public GameObject respawnPoint;
	public GameObject respawn1;
	public GameObject respawn2;
	public GameObject respawn3;

	Coroutine knockbackReference;

	float currentTimer;
	float maxTimer = 2f;

	public Sprite heartOn;
	public Sprite heartOff;
	bool isHurt;

	Animator anim;

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		Debug.Log(currentHealth);
	}

	void UpdateHpBar()
	{
		for (int i = 0; i < startingHealth; i++)
		{

			if(currentHealth > i)
			{
				hpImages [i].GetComponent<Image>().sprite = heartOn;
			}
			else
			{
				hpImages [i].GetComponent<Image>().sprite = heartOff;
			}
		}
	}

	IEnumerator Knockback(Vector3 direction)
	{
		for(float back = 1f ; back < 1.1f; back += 0.01f)
		{
			transform.Translate(direction * back);
		}
		yield return null;
		StopAllCoroutines();
	}

	// Use this for initialization
	void Awake () 
	{
		currentHealth = startingHealth;
	}

	void Start ()
	{
		respawnPoint = spawnPoint;
		currentTimer = maxTimer;
		isHurt = false;
		anim = GetComponent<Animator>();
	}

	void Respawn ()
	{
		transform.position = respawnPoint.transform.position;
		currentHealth = startingHealth;
		anim.Play("IdleDown");
		GetComponent<PlayerActions>().enabled = true;
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.CompareTag("Entrance1"))
		{
			FirstEntrance entrance = target.GetComponent<FirstEntrance>();
			if(entrance.firstEntry == false)
			{
				entrance.firstEntry = true;
				startingHealth += 1;
				GameObject go = Instantiate(hpImage,hpImages[0].transform.parent);
				hpImages.Add(go);
			}

			currentHealth = startingHealth;
			respawnPoint = respawn1;
		}
		if (target.CompareTag("Entrance2"))
		{
			FirstEntrance entrance = target.GetComponent<FirstEntrance>();
			if(entrance.firstEntry == false)
			{
				entrance.firstEntry = true;
				startingHealth += 1;
				GameObject go = Instantiate(hpImage,hpImages[0].transform.parent);
				hpImages.Add(go);
			}

			currentHealth = startingHealth;
			respawnPoint = respawn2;
		}
		if (target.CompareTag("Entrance3"))
		{
			FirstEntrance entrance = target.GetComponent<FirstEntrance>();
			if(entrance.firstEntry == false)
			{
				entrance.firstEntry = true;
				startingHealth += 1;
				GameObject go = Instantiate(hpImage,hpImages[0].transform.parent);
				hpImages.Add(go);
			}

			currentHealth = startingHealth;
			respawnPoint = respawn3;
		}

		//if(target.CompareTag("Enemy") || target.CompareTag("RangeAttack") || target.CompareTag("Fire"))
		if(target.CompareTag("RangeAttack") || target.CompareTag("Fire"))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(transform.position, target.transform.position);
			if(hit.transform != null)
			{
				Debug.Log("player was hit");
			}

			if(!isHurt)
			{
				TakeDamage(1);
			}

			isHurt = true;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateHpBar ();
		if(currentHealth <= 0)
		{
			GetComponent<PlayerActions>().enabled = false;
			currentHealth = 0;
			randomDeathDirection = Random.Range(1, 3);
			if (randomDeathDirection == 1)
			{
				anim.Play("PlayerDeathLeft");	
			}
			else if (randomDeathDirection == 2)
			{
				anim.Play("PlayerDeathLeft");
			}
		}

		if(isHurt)
		{
			if(currentTimer <= 0)
			{
				currentTimer = maxTimer;
				isHurt = false;
			}
			currentTimer -= Time.smoothDeltaTime;
		}

		if(Input.GetKeyDown(KeyCode.F1))
		{
			Application.Quit();
		}
	}
}
