using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	public Transform gameOver;
	public Transform youWin;
	public Animator Anim;
	public Transform MageFireball;
	Vector3 Velocity = Vector3.zero;
	float Speed;
    float Gravity = 20.0f;
	public bool MoveRight = true;
	int TimeSinceAttack;
	int AttackLength;
	bool AttackAnimation;
	bool ProjectileCharacter;
	public int Health;
	bool DeathAnimationActive = false;
	int TimeSinceDeath;
	int DeathLength;
	bool Dead = false;
	bool YouWin = false;
	AudioSource audio;

	// Use this for initialization
	void Start () {
        Anim = this.GetComponent<Animator> ();
		audio = this.GetComponent<AudioSource> ();
		Speed = 1.0f;
		TimeSinceAttack = 0;
		AttackLength = 40;
		AttackAnimation = false;
		Health = 100;
		DeathLength = 50;
		TimeSinceDeath = 0;
		print ("success");
		GameObject Holder = GameObject.FindGameObjectWithTag ("Holder");
		int Chosen = Holder.GetComponent<CharacterHolder> ().GetCharacter ();
		if (Chosen == 0) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load ("FemaleMageSprite") as Sprite;
			Anim.runtimeAnimatorController = Resources.Load ("FemaleMageController") as RuntimeAnimatorController;
			ProjectileCharacter = true;
			Health = 100;
		} else if (Chosen == 1) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load ("MaleKnightSprite") as Sprite;
			Anim.runtimeAnimatorController = Resources.Load ("MaleKnightController") as RuntimeAnimatorController;
			ProjectileCharacter = false;
			Health = 150;
		} else if (Chosen == 2) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load ("MachineGunGuySprite") as Sprite;
			Anim.runtimeAnimatorController = Resources.Load ("MachineGunGuyController") as RuntimeAnimatorController;
			ProjectileCharacter = true;
			Health = 100;
		} else if (Chosen == 3) {
			GetComponent<SpriteRenderer> ().sprite = Resources.Load ("FemaleKnightSprite") as Sprite;
			Anim.runtimeAnimatorController = Resources.Load ("FemaleKnightController") as RuntimeAnimatorController;
			ProjectileCharacter = false;
			Health = 150;
		}
    }
    
/*  public void OnStartLocalPlayer(){
		GameObject Holder = GameObject.FindGameObjectWithTag ("Holder");
		int Choosen = Holder.GetComponent<CharacterHolder> ().GetCharacter ();
		print("success 1");
		if (Choosen == 0) {
			Anim.runtimeAnimatorController = Resources.Load ("FemaleMage") as RuntimeAnimatorController;
		} else if (Choosen == 1) {
			print ("success");
			Anim.runtimeAnimatorController = Resources.Load ("animations/MaleKnight/MaleKnight") as RuntimeAnimatorController;
		} else if (Choosen == 2) {

		} else if (Choosen == 3) {

		}
    }*/

    // Update is called once per frame
    void Update () {

		if (!YouWin) {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene ("Help");
			}
		} else if (YouWin) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("MainMenu");
			}
		}

		if (YouWin) {
			return;
		}

		if (Dead) {
			Destroy (gameObject);
			return;
		}
		CharacterController Controller = GetComponent<CharacterController>();
		if (DeathAnimationActive) {
			TimeSinceDeath++;
			Anim.SetInteger ("WhichAnim", 10);
			if (TimeSinceDeath >= DeathLength) {
				Dead = true;
				Instantiate (gameOver, transform.position, transform.rotation);
			}
			GetComponent<CharacterController> ().enabled = false;
			return;
		}

		if (AttackAnimation) {
			TimeSinceAttack++;
			if (TimeSinceAttack >= AttackLength) {
				AttackAnimation = false;
				if (!ProjectileCharacter) {
					transform.Find ("PlayerHitbox").GetComponent<PlayerHitbox> ().AILocation (MoveRight);
				} else if (ProjectileCharacter) {
					if (MoveRight) {
						Vector3 Position = new Vector3 (transform.position.x + .5f, transform.position.y, transform.position.z);
						audio.Play ();
						Instantiate (MageFireball, Position, transform.rotation);
					} else if (!MoveRight) {
						Vector3 Position = new Vector3 (transform.position.x - .5f, transform.position.y, transform.position.z);
						audio.Play ();
						Instantiate (MageFireball, Position, transform.rotation);
					}
				}
			}
		}

		if (Controller.isGrounded && !AttackAnimation) {
			Velocity = new Vector3 (Input.GetAxis ("Horizontal") * Speed, 0, 0);

			if (Velocity.x == 0 && MoveRight && !Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 0);
				Speed = 1.0f;
			} else if (Velocity.x == 0 && !MoveRight && !Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 1);
				Speed = 1.0f;
			} else if (Velocity.x > 0 && !Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 2);
				MoveRight = true;
				Speed = 1.0f;
			} else if (Velocity.x < 0 && !Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 3);
				MoveRight = false;
				Speed = 1.0f;
			} else if (Velocity.x > 0 && Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 4);
				MoveRight = true;
				Speed = 3.0f;
			} else if (Velocity.x < 0 && Input.GetKey (KeyCode.LeftShift)) {
				Anim.SetInteger ("WhichAnim", 5);
				MoveRight = false;
				Speed = 3.0f;
			}

			if (Input.GetKeyDown (KeyCode.Space) && MoveRight) {
				Anim.SetInteger ("WhichAnim", 6);
				Velocity.y += 5;
			} else if (Input.GetKeyDown (KeyCode.Space) && !MoveRight) {
				Anim.SetInteger ("WhichAnim", 7);
				Velocity.y += 5;
			}

			if (Input.GetMouseButtonDown (0) && MoveRight) {
				Anim.SetInteger ("WhichAnim", 8);
				TimeSinceAttack = 0;
				AttackAnimation = true;
				Velocity.x = 0;
			} else if (Input.GetMouseButtonDown (0) && !MoveRight) {
				Anim.SetInteger ("WhichAnim", 9);
				TimeSinceAttack = 0;
				AttackAnimation = true;
				Velocity.x = 0;
			}

		}

		if (transform.position.x > GameObject.FindGameObjectWithTag ("Helicopter").transform.position.x) {
			SceneManager.LoadScene ("Scene2");
		} else if (transform.position.x > GameObject.FindGameObjectWithTag ("Helicopter2").transform.position.x) {
			SceneManager.LoadScene ("Scene3");
		} else if (transform.position.x > GameObject.FindGameObjectWithTag ("Helicopter3").transform.position.x) {
			Instantiate (youWin, transform.position, transform.rotation);
			YouWin = true;
		}

		GameObject.Find ("Main Camera").GetComponent<CameraScript> ().currPlayer = this.transform;

        Velocity.y -= Gravity * Time.deltaTime;
		Controller.Move(Velocity * Time.deltaTime);
	}

	public void Damage(int Damage){
		Health -= Damage;
		transform.GetComponent<Combat> ().TakeDamage (Damage);
		if (Health <= 0) {
			Anim.SetInteger ("WhichAnim", 10);
			DeathAnimationActive = true;
		}
	}
}
