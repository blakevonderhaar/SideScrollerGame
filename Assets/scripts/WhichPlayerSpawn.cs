using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WhichPlayerSpawn : NetworkBehaviour {

	public Transform mage;
	public Transform gunMan;
	public Transform knight;

	public int whichChar;
	Animator anim;
	SpriteRenderer spriteRen;
	NetworkAnimator netAnim;

	Animator organim;
	SpriteRenderer orgspriteRen;
	NetworkAnimator orgnetAnim;


	// Use this for initialization
	void Start () {
		print ("joe");
		if (!isLocalPlayer) {
			return;
		}
		print ("billy");
		whichChar = GameObject.Find ("PlayerSelect").GetComponent<CharacterSelectionScript> ().index;
		print (whichChar);

		if (whichChar == 0) {
			anim = mage.GetComponent<Animator>();
			spriteRen = mage.GetComponent<SpriteRenderer>();
			netAnim = mage.GetComponent<NetworkAnimator> ();
		}else if (whichChar == 1) {
			anim = gunMan.GetComponent<Animator>();
			spriteRen = gunMan.GetComponent<SpriteRenderer>();
			netAnim = gunMan.GetComponent<NetworkAnimator> ();
		}else if (whichChar == 2) {
			anim = knight.GetComponent<Animator>();
			spriteRen = knight.GetComponent<SpriteRenderer>();
			netAnim = knight.GetComponent<NetworkAnimator> ();
		}

		organim = GetComponent<Animator> ();
		orgspriteRen = GetComponent<SpriteRenderer> ();
		orgnetAnim = GetComponent<NetworkAnimator> ();

		organim.runtimeAnimatorController = anim.runtimeAnimatorController;
		orgspriteRen.sprite = spriteRen.sprite;
		orgnetAnim.animator  = netAnim.animator;



	}

}
