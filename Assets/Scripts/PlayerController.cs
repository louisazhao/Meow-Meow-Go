using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float playerMovingSpeed=10.0f;
	private float TempSpeed;
	private float maxSpeed = 40.0f;

	public GameObject endFlag;

	public float jumpVelocity = 100f;
	public KeyCode moveL;
	public KeyCode moveR;
	public KeyCode jump;
	public KeyCode spellKey;
	public Image damageFlash;
	public AudioClip gameOverSound;
	public AudioClip spellCasting;
	public AudioClip hurtSound;
	public float flashSpeed=5f;
	public Color flashColor=new Color(1f,0f,0f,0.1f);
	public Transform faintEffectSpawnPos;
	public ParticleSystem faintEffect;
	public ParticleSystem healEffect;
	public ParticleSystem shieldEffect;


	private float horizontalVel = 0.0f;
	private Rigidbody rb;
	private Animator anim;
	private float startDelay=4f;
	private float timer=0;
	private int lanNum = 2;
	private bool controlLock = false;
	private bool isGround=true;
	private bool isInvcible = false;
	private AudioSource playerSound;

	//TODO health
	private int maxPlayerHP=5;
	public int currentPlayerHP;
	private bool isDead=false;
	private bool damaged;

	public GameObject pathG;

	public int score;

	//TODO Enegy
	private int maxEnegy=4;
	private int currentEnegy;

	//UI 
	public GameObject[] playerLifeIM;
	public GameObject spellButton;
	public Text scoreUI;
	public GameObject cameraMain;

	public  void Init()
	{
		foreach (GameObject im in playerLifeIM)
			im.SetActive (true);
		scoreUI.text = score.ToString ();
			
	}

	void Start () 
	{	
		
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		playerSound = GetComponent<AudioSource> ();
		currentPlayerHP = maxPlayerHP;
		score = 0;
		currentEnegy = 0;
//		spellButton = GameObject.FindGameObjectWithTag ("SpellButton");
		spellButton.SetActive (false);
		isInvcible = false;

	}

	void Update()
	{
		if (damaged) {
			damageFlash.color = flashColor;
		} 
		else 
		{
			damageFlash.color = Color.Lerp (damageFlash.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;

		if (readyToSpell ()) 
		{
			spellButton.SetActive (true);
		}


	}
	

	void FixedUpdate () 
	{
		timer += Time.deltaTime;
		if (timer >= startDelay) {
			anim.SetTrigger ("Start");
			rb.velocity = new Vector3 (horizontalVel, 0.0f, playerMovingSpeed);

			if (Input.GetKeyDown (moveL) && (lanNum > 1) && (controlLock == false)) {
				horizontalVel = -3.0f;
				controlLock = true;
				StartCoroutine (stopSlide ());
				lanNum -= 1;
			}
			if (Input.GetKeyDown (moveR) && (lanNum < 3) && (controlLock == false)) {
				horizontalVel = 3.0f;
				controlLock = true;
				StartCoroutine (stopSlide ());
				lanNum += 1;
			}
			if (Input.GetKeyDown (jump) && (isGround == true)) {
				rb.AddForce (0.0f, jumpVelocity, 0.0f, ForceMode.Impulse);
				isGround = false;
			}
			/*
			if (Input.GetKeyDown (spellKey) && (readyToSpell () == true) && (!isDead)) 
			{
				castSpell ();
			}
			*/
				
		}

	}

	//control the movement to left and right, such that the player will stop the movement after 0.5 seconds
	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds (0.5f);
		horizontalVel = 0.0f;
		controlLock = false;
	}

	//determine if the player has landed
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ground") {
			isGround = true;
		}
	}

	void OnTriggerExit(Collider cl)
	{
		if (cl.gameObject.tag == "NextPath")
			pathG.GetComponent<PathGenerator> ().currPathNum--;
			Destroy (cl.gameObject,2f);
		}

	void OnTriggerEnter(Collider other)
	{
		//enemy
		if ((other.tag == "Enemy") &&( !isInvcible ) )
		{
			controlLock = true;
			TakeDamage();
			Destroy(other.gameObject);
		}else if((other.tag == "Enemy") && ( isInvcible ))
		{
			controlLock = true;
			Destroy (other.gameObject);
			isInvcible = false;
		}

		//stone
		if ((other.tag == "Stone") &&( !isInvcible ) )
		{
			controlLock = true;
			cameraMain.GetComponent<CameraFollow> ().ShakingCam ();
			TakeDamage();
			Destroy(other.gameObject);
		}else if ((other.tag == "Stone") &&( isInvcible ) )
		{
			controlLock = true;
			isInvcible = false;
			Destroy(other.gameObject);
		}



		if (other.tag == "coin") 
		{
			score += 10;
			scoreUI.text = score.ToString ();
			Destroy (other.gameObject);
			//diffculty
			SpeedUp ();
		}

		if (other.tag == "enegy") 
		{
			if (currentEnegy < maxEnegy) 
			{
				currentEnegy += 1;
			}
			Destroy (other.gameObject);
		}
	}

	IEnumerator fainting()
	{
		if (currentPlayerHP>0) {
			yield return new WaitForSeconds (2f);
			playerMovingSpeed = TempSpeed;
			controlLock = false;
		}
		if (currentPlayerHP <= 0) 
		{
			yield return new WaitForSeconds (4f);
			SceneManager.LoadScene("GameOverScene");
		}
	}


	void TakeDamage()
	{
		if (currentPlayerHP>0&&isDead == false) 
		{
			damaged = true;
			TempSpeed = playerMovingSpeed;
			playerMovingSpeed = 0.0f;
			currentPlayerHP -= 1;
			CheckCurrentLife (currentPlayerHP);
			StartCoroutine (fainting ());
			playerSound.clip = hurtSound;
			playerSound.Play ();
			anim.SetTrigger ("damaged");
			Instantiate (faintEffect, faintEffectSpawnPos.position,Quaternion.identity);
		}
		if (currentPlayerHP <= 0 && !isDead) 
		{  
			foreach (GameObject im in playerLifeIM)
				im.SetActive (false);
			GameOver();
		}
	}

	void GameOver()
	{
		
		isDead = true;
		anim.SetTrigger ("Die");
		playerSound.clip = gameOverSound;
		playerSound.Play ();
		playerMovingSpeed = 0.0f;

	//	SceneManager.LoadScene("GameOverScene");
	}

	bool readyToSpell()
	{
		return (currentEnegy >= 4);
	}


	public void Heal()
	{
		if (currentPlayerHP < maxPlayerHP && currentPlayerHP != 0) 
		{
			Instantiate (healEffect, transform);
			playerSound.clip = spellCasting;
			playerSound.Play ();
			currentPlayerHP += 1;
			CheckCurrentLife (currentPlayerHP);
			currentEnegy = 0;
			spellButton.SetActive (false);
		}
	}

	public void Shiled()
	{
		if ( currentPlayerHP != 0 && !isInvcible) 
		{
			Instantiate (shieldEffect, transform);
			playerSound.clip = spellCasting;
			playerSound.Play ();
			isInvcible = true;
			StartCoroutine(Invincible());
			currentEnegy = 0;
			spellButton.SetActive (false);
		}
	}

	IEnumerator Invincible()
	{
		yield return new WaitForSeconds (5f);
		isInvcible = false;

	}
	//TODO: DoubleGold,FireBall
	public void DoubleGold()
	{	
		currentEnegy = 0;
		spellButton.SetActive (false);
	}



	public void FireBall()
	{
		Debug.Log ("Clicked");
		currentEnegy = 0;
		spellButton.SetActive (false);
	}

	public void CheckCurrentLife(int i)
	{	
		//if curHP = maxHp, ALL LIFEiMAGE ACTIVE
		if (i == maxPlayerHP) 
		{
			foreach (GameObject im in playerLifeIM)
				im.SetActive (true);
		}

		// IF CURHP < MAXHP
		int temp1 = i;
		int temp2 = i;
		//DEACTIVE DAMAGED HEALTH
		while(temp1 < maxPlayerHP)
		{
			playerLifeIM[temp1].SetActive(false);
			temp1++;
		}
		//MAKESURE ACTIVE CURHP
		while(temp2 > 0)
		{
			playerLifeIM [temp2 - 1].SetActive (true);
			temp2--;
		}

	}

	private void SpeedUp()
	{    
		if (playerMovingSpeed < maxSpeed) {
			int temp = score % 50;
			if (temp == 0) {
				//ever 50 score get speed up 
				playerMovingSpeed = playerMovingSpeed + playerMovingSpeed  * 0.1f;
			}

		} else
			playerMovingSpeed = maxSpeed;

	}

}
