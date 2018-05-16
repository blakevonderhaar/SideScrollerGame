using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	public Animator anim;
	int animValue;
	Vector3 velocity = Vector3.zero;
	float gravity = 20.0f;
	bool right;
	int health;
	float speed;
	float move;
	int animInt;
	bool attacking;

	bool dead;
	float deathTime;
	bool hit;
	float hitTime;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		speed = .8f;
		animInt = 1;
		right = true;
		attacking = false;
		health = 40;
		hitTime = 0;
		hit = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
// once the AI dies it will be destroyed
		if (dead) 
		{
			GetComponent<CharacterController> ().enabled = false;
			deathTime += Time.deltaTime;
			anim.SetInteger ("whichAnim", 2);
			if (deathTime >= 1) {
				Destroy (gameObject);
			}
			return;
		}


		if (velocity.x > 0) {
			right = true;
		} else if (velocity.x < 0) {
			right = false;
		}
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			if (transform.Find ("chasebox").GetComponent<ChasePlayer> ().player != null) 
			{
				Collider player = transform.Find ("chasebox").GetComponent<ChasePlayer>().player;
				if (player.bounds.center.x > transform.position.x && !attacking) 
				{
					right = true;
					transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
					move = 1f;
					animInt = 0;
				} 
				else if (player.bounds.center.x < transform.position.x && !attacking)
				{
					right = false;
					transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
					move = -1f;
					animInt = 0;
				}
			}
			else if (hit && !attacking) 
			{
				if (right) 
				{
					right = false;
					transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
					move = -1f;
					animInt = 0;
				} 
				else if (!right) 
				{
					right = true;
					transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
					move = 1f;
					animInt = 0;
				}
			} 
			else if (transform.Find ("chasebox").GetComponent<ChasePlayer> ().player == null && right && !attacking) 
			{
				transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
				move = 1f;
				animInt = 0;
			} 
			else if (transform.Find ("chasebox").GetComponent<ChasePlayer> ().player == null && !right && !attacking)
			{
				transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
				move = -1f;
				animInt = 0;
			} 
			hit = false;
			velocity = new Vector3 (move * speed, 0, 0);
		}

//AI will stop and attack at the player once the player enters the hitbox
		if (transform.Find ("hitbox") != null)
		if (transform.Find ("hitbox").GetComponent<AIHitbox> ().right) {
			if (transform.Find ("hitbox").GetComponent<AIHitbox> ().attack && !attacking) {
				attacking = true;
				right = true;
				transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
				velocity.x = 0;
				animInt = 1;
			}
		} else if (!transform.Find ("hitbox").GetComponent<AIHitbox> ().right) {
			if (transform.Find ("hitbox").GetComponent<AIHitbox> ().attack && !attacking) {
				attacking = true;
				right = false;
				transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
				velocity.x = 0;
				animInt = 1;
			}
		} 
// this times the AI attacking animation to deal damage to the player
		if (attacking) 
		{
			hitTime += Time.deltaTime;
			if (hitTime >= .95f) 
			{
				attacking = false;
				hitTime = 0;
				if (transform.Find ("hitbox").GetComponent<AIHitbox> ().player != null) 
				{
					transform.Find ("hitbox").GetComponent<AIHitbox> ().player.GetComponent<Player> ().Damage (10);
					if (transform.Find ("hitbox").GetComponent<AIHitbox> ().player.GetComponent<Player> ().Health <= 0) 
					{
						attacking = false;
						transform.Find ("hitbox").GetComponent<AIHitbox> ().player = null;
						transform.Find ("hitbox").GetComponent<AIHitbox> ().attack = false;
						transform.Find ("chasebox").GetComponent<ChasePlayer> ().player = null;
					}
				}
			}
		}
// when the Player isn't in the hitbox the AI will stop attacking
		if(!transform.Find ("hitbox").GetComponent<AIHitbox> ().attack)
		{
			attacking = false;
			hitTime = 0;
		}
// when the AI hits a wall it will go the other way


		anim.SetInteger ("whichAnim", animInt);
		velocity.y -= gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);



	}

	void OnControllerColliderHit(ControllerColliderHit obj)
	{
// if the AI walks into another AI it will change direction if it isn't chasing a player
		if (obj.transform.tag == "AI") 
		{
			if (transform.Find ("hitbox").GetComponent<AIHitbox> ().player == null
			    && transform.Find ("chasebox").GetComponent<ChasePlayer> ().player == null)
				hit = true;
			else
				hit = false;
		}
		else if(obj.transform.tag == "Wall")
		{
			hit = true;
		}
	}
	public void Damage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			health = 0;
			dead = true;
			deathTime = 0;
			audio.Play ();
		}
		if (right)
			transform.Translate (-.1f, 0, 0);
		else if (!right)
			transform.Translate (.1f, 0, 0);
	}

	void OnTriggerEnter(Collider Other){
		if (Other.tag == "Projectile") {
			Damage (10);
		}
	}
}
