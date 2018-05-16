using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class instanceAI : MonoBehaviour
{
	public GameObject Character;
	public GameObject SkeletonAI;
	public GameObject OrcAI;
	float time;
	bool skel;
	int AIcount = 0;
	// Use this for initialization
	public void  Start () {
		time = 0;
		skel = true;
		//Instantiate (SkeletonAI, new Vector3(5,0,0), transform.rotation);
		//Instantiate (SkeletonAI, new Vector3(12,0,0), transform.rotation);
		//Instantiate (OrcAI, new Vector3(20,0,0), transform.rotation);
		//Instantiate (OrcAI, new Vector3(15,0,0), transform.rotation);
		Instantiate(Character, new Vector3(0, 0, 0), transform.rotation);
        Instantiate(SkeletonAI, new Vector3(-5, 0, 0), transform.rotation);
        Instantiate(SkeletonAI, new Vector3(12, 0, 0), transform.rotation);
        Instantiate(OrcAI, new Vector3(30, 0, 0), transform.rotation);
        Instantiate(OrcAI, new Vector3(45, 0, 0), transform.rotation);
		Instantiate(SkeletonAI, new Vector3(-7, 0, 0), transform.rotation);
		Instantiate(SkeletonAI, new Vector3(14, 0, 0), transform.rotation);
		Instantiate(OrcAI, new Vector3(32, 0, 0), transform.rotation);
		Instantiate(OrcAI, new Vector3(47, 0, 0), transform.rotation);
    }
	void Update ()
	{
		time += Time.deltaTime;
		if (time > 10 && AIcount < 12) {
			skel = !skel;
			if (skel) {
				GameObject skel1 = Instantiate (SkeletonAI, new Vector3 (Random.Range (-10, 50), 0, 0), transform.rotation);
				Instantiate(SkeletonAI, new Vector3(-5, 0, 0), transform.rotation);
			}
			else if (!skel) {
				GameObject Orc1 = Instantiate (OrcAI, new Vector3 (Random.Range (-10, 50), 0, 0), transform.rotation);
				Instantiate(OrcAI, new Vector3(30, 0, 0), transform.rotation);
			}
			time = 0;
			AIcount++;
		}

		AIcount = GameObject.FindGameObjectsWithTag ("AI").Length;

	}

    
}
