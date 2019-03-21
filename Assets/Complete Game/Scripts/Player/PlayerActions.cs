using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour {

	public GameObject[] comboReference = new GameObject[3];
//	public Image dashCooldown;
	public LayerMask blockingLayer;

	int combo = 0;
	float lastAttackPressed = 0;
	float maxComboDelay = 1;

	Animator anim;
	Coroutine dashReference;
	Coroutine dashIntervalRef;
	Coroutine attackReference;

	Vector3 velocity;

	GameObject tree;

	PolygonCollider2D selfCollider;
	Rigidbody2D rgb2d;

	char animInspector;
	bool finishDash;
	bool attack;
	float dash;
	float speed;
	public DashCooldownBar dashScript;

	float velocityX;
	float velocityY;

	// Player Attack
	IEnumerator PlayerAttack() {
		yield return null;

		if( Input.GetKeyDown(KeyCode.X) && !attack)
		{
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_PLAYERATTACK);
			velocity = Vector3.zero;
			combo++;
			lastAttackPressed = Time.time;
			attack = true;
			if(combo > 3)
			{
				combo = 0;
				yield return new WaitForSeconds(0.2f);
			}
			else if(combo > 0 && combo <= 3)
			{
//				if(animInspector == 'R')
//					velocity.x+= 0.1f;
//				else if(animInspector == 'L')
//					velocity.x-= 0.1f;
//				else if(animInspector == 'U')
//					velocity.y+= 0.1f;
//				else if(animInspector == 'D')
//					velocity.y-= 0.1f;
////
//				transform.Translate(velocity);
				
				// First Combo
				if(combo == 1)
				{
					comboReference[0].SetActive(true);
					if(animInspector == 'U')
					{
						anim.Play("ComboUp1");
					}
					else if(animInspector == 'L')
					{
						anim.Play("ComboLeft1");
					}
					else if(animInspector == 'D')
					{
						anim.Play("ComboDown1");
					}
					else if(animInspector == 'R')
					{
						anim.Play("ComboRight1");
					}
					yield return new WaitForSeconds (0.5f);
					comboReference[0].SetActive(false);
					if(animInspector == 'U')
					{
						anim.Play("IdleUp");
					}
					else if(animInspector == 'L')
					{
						anim.Play("IdleLeft");
					}
					else if(animInspector == 'D')
					{
						anim.Play("IdleDown");
					}
					else if(animInspector == 'R')
					{
						anim.Play("IdleRight");
					}
				}
				// Second Combo
				else if( combo == 2)
				{
					comboReference[1].SetActive(true);
					if(animInspector == 'U')
					{
						anim.Play("ComboUp2");
					}
					else if(animInspector == 'L')
					{
						anim.Play("ComboLeft2");
					}
					else if(animInspector == 'D')
					{
						anim.Play("ComboDown2");
					}
					else if(animInspector == 'R')
					{
						anim.Play("ComboRight2");
					}
					yield return new WaitForSeconds (0.5f);
					comboReference[1].SetActive(false);
					if(animInspector == 'U')
					{
						anim.Play("IdleUp");
					}
					else if(animInspector == 'L')
					{
						anim.Play("IdleLeft");
					}
					else if(animInspector == 'D')
					{
						anim.Play("IdleDown");
					}
					else if(animInspector == 'R')
					{
						anim.Play("IdleRight");
					}
				}
				// Third Combo
				else if( combo == 3 )
				{
					comboReference[2].SetActive(true);
					if(animInspector == 'U')
					{
						anim.Play("ComboUp3");
					}
					else if(animInspector == 'L')
					{
						anim.Play("ComboLeft3");
					}
					else if(animInspector == 'D')
					{
						anim.Play("ComboDown3");
					}
					else if(animInspector == 'R')
					{
						anim.Play("ComboRight3");
					}
					yield return new WaitForSeconds (0.8f);
					comboReference[2].SetActive(false);
					if(animInspector == 'U')
					{
						anim.Play("IdleUp");
					}
					else if(animInspector == 'L')
					{
						anim.Play("IdleLeft");
					}
					else if(animInspector == 'D')
					{
						anim.Play("IdleDown");
					}
					else if(animInspector == 'R')
					{
						anim.Play("IdleRight");
					}
				}
			}
			attack = false;
		}
	}

	IEnumerator Dash()
	{
//		finishDash = false;
//		hit = Physics2D.Linecast (start, end, blockingLayer);
		for(dash = 1f; dash < 8; dash++)
		{
			if(animInspector == 'L')
			{
				if(Move(-dash, 0.0f))
				{
					DashMove(new Vector3(-dash, 0, 0));
					//anim.Play("DashLeft");
				}
			}
			else if(animInspector == 'R')
			{
				if(Move(dash, 0.0f))
				{
					DashMove(new Vector3(dash, 0, 0));
					//anim.Play("DashRight");
				}
			}
			else if(animInspector == 'U')
			{
				if(Move(0.0f, dash))
				{
					DashMove(new Vector3(0, dash, 0));
					//anim.Play("DashUp");
				}
			}
			else if(animInspector == 'D')
			{
				if(Move(0.0f, -dash))
				{
					DashMove(new Vector3(0, -dash, 0));
					//anim.Play("DashDown");
				}
			}


			yield return null;
			//Debug.Log("dash " + dash);
		}

		if(animInspector == 'L')
		{
			anim.Play("IdleLeft");
		}
		else if(animInspector == 'R')
		{
			anim.Play("IdleRight");
		}
		else if(animInspector == 'U')
		{
			anim.Play("IdleUp");
		}
		else if(animInspector == 'D')
		{
			anim.Play("IdleDown");
		}
		//Debug.Log("dashcounter" + dash);
		//yield return new WaitForSeconds(0.3f);
//		finishDash = true;
	}

	void DashMove(Vector3 dash)
	{
//		if(!MoveDash())
			transform.Translate (dash * Time.deltaTime , Space.World);
//		Rigidbody2D rig = GetComponent<Rigidbody2D>();
//		rig.AddForce(new Vector2(dash.x*1000,dash.y),ForceMode2D.Impulse);
	}

	// Interval after doing dash
	IEnumerator DashInterval()
	{
		for (int i = 1; i <= 3; i++)
		{
			speed += i;
			yield return new WaitForSeconds(0.3f);
			yield return null;
		}
	}

	// Direction of player, so the weapon will follow its direction
	void MovementDirection(Vector3 katanaDirection, float x, float y, char direction)
	{
		for(int i = 0; i < 3; i++)
		{
			comboReference[i].transform.localRotation = Quaternion.Euler(katanaDirection);
			comboReference[i].transform.position = new Vector3(this.transform.position.x + x, this.transform.position.y + y, this.transform.position.z );
		}
		animInspector = direction;
	}

	// Basic movement
	void Movement(float xDir, float yDir)
	{
		if(Time.timeScale != 0)
		{
			velocity.x = xDir;
			velocity.y = yDir;
			transform.Translate (velocity * Time.deltaTime * speed, Space.World);

			//		rgb2d.velocity = velocity * speed;

			//		if(!finishDash)
			//		{
			if (Input.GetKey (KeyCode.RightArrow) )
			{
				MovementDirection(new Vector3(0,180,0), 0.6f, 0, 'R');
				anim.Play ("WalkRight");
			}

			else if (Input.GetKey (KeyCode.LeftArrow) )
			{
				MovementDirection(Vector3.zero, -0.6f, 0, 'L');
				anim.Play ("WalkLeft");
			}

			else if (Input.GetKey (KeyCode.UpArrow) )
			{
				MovementDirection(new Vector3(0,0,270), 0, 0.6f, 'U');
				anim.Play ("WalkUp");
			}

			else if (Input.GetKey (KeyCode.DownArrow) )
			{
				MovementDirection(new Vector3(0,0,90), 0, -0.6f, 'D');
				anim.Play ("WalkDown");
			}
			//		}


			if(Input.GetKeyUp(KeyCode.RightArrow) && animInspector == 'R')
				anim.Play ("IdleRight");
			else if(Input.GetKeyUp(KeyCode.LeftArrow) && animInspector == 'L')
				anim.Play ("IdleLeft");
			else if(Input.GetKeyUp(KeyCode.UpArrow) && animInspector == 'U')
				anim.Play ("IdleUp");
			else if(Input.GetKeyUp(KeyCode.DownArrow) && animInspector == 'D')
				anim.Play ("IdleDown");
		}

	}

	public void WalkingSound()
	{
		SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_WALKING);
	}

	void VelocityValue()
	{
			velocity = Vector3.zero;
			velocityX = 0;
			velocityY = 0;
			if(Input.GetKey(KeyCode.UpArrow))
			{
				velocityY++;
				velocity.y = velocityY;
			}
			else if(Input.GetKey(KeyCode.DownArrow))
			{
				velocityY--;
				velocity.y = velocityY;
			}
			if(Input.GetKey(KeyCode.RightArrow))
			{
				velocityX++;
				velocity.x = velocityX;
			}
			else if(Input.GetKey(KeyCode.LeftArrow))
			{
				velocityX--;
				velocity.x = velocityX;
			}

	}

	void Awake()
	{
		attack = false;
		dash = 0;
		speed = 3f;
		anim = GetComponent<Animator> ();

		for(int i = 0; i < comboReference.Length; i++)
		{
			comboReference[i].SetActive(false);
		}
	}

	void Start()
	{
		finishDash= true;
		rgb2d = GetComponent<Rigidbody2D>();
		selfCollider = GetComponent<PolygonCollider2D>();
	}

	// Prevent enemy from moving into the wall
	void FixedUpdate ()
	{
		if (Dialogue.Instance.canMove)
		{
			if(!attack && CameraController.Instance.Movement == false)
			{
				AttemptMove (velocityX, velocityY);
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
//		if (CameraController.Instance.Movement == false)
//		{
//			VelocityValue();
//		}

		VelocityValue();
		if(Input.GetKeyUp(KeyCode.RightArrow) && animInspector == 'R')
			anim.Play ("IdleRight");
		else if(Input.GetKeyUp(KeyCode.LeftArrow) && animInspector == 'L')
			anim.Play ("IdleLeft");
		else if(Input.GetKeyUp(KeyCode.UpArrow) && animInspector == 'U')
			anim.Play ("IdleUp");
		else if(Input.GetKeyUp(KeyCode.DownArrow) && animInspector == 'D')
			anim.Play ("IdleDown");
//		Debug.Log("horizontal = " + velocityX + " vertical = " + velocityY);
//		Debug.Log(finishDash);

		if(Time.time - lastAttackPressed > maxComboDelay)
		{
			combo = 0;
		}

//		if(!attack && finishDash)
//		{
//			Movement();
//		}

		attackReference = StartCoroutine(PlayerAttack());

		// Player press Dash button

		if(dashScript.alreadyDash == true)
		{
			finishDash = true;
//			Debug.Log("dash " + dashScript.alreadyDash);
		}
		else
		{
			finishDash = false;
		}

		// Interval after doing dash
//		if(!finishDash)
//		{
//			//StartCoroutine(DashInterval());
//			finishDash = true;
//		}

	}

	bool Move (float xDir, float yDir)
	{
		Vector2 start = transform.position;
		float x = xDir * 0.1f;
		float y = yDir * 0.1f;
		Vector2 end = start + new Vector2 (x, y);

		RaycastHit2D hit = Physics2D.Linecast (start, end, blockingLayer);
//		Debug.Log("end = " + end);
		if(hit.transform == null)
		{
			return true;
		}
		return false;
	}

	void AttemptMove(float xDir, float yDir)
	{
		bool canMove = Move (xDir, yDir);
//		Debug.Log("canMove = " + canMove);

		if(canMove == true)
		{
//			Debug.Log("available to move");
			Movement(xDir, yDir);

			if( Input.GetKeyDown(KeyCode.Z) && finishDash)
			{
				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_PLAYERDASH);
				dashReference = StartCoroutine(Dash());
//				Debug.Log("dash!");
			}
		}
	}
}
