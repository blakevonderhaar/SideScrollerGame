using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{

    float xVelocity = 0;
    float smoothTime = .6f;

	public Transform currPlayer;

    // Use this for initialization
    void Start()
    {
		transform.position = new Vector3(transform.position.x,
            transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		if (currPlayer != null) {
			float numPos = Mathf.SmoothDamp (transform.position.x, currPlayer.position.x,
				                    ref xVelocity, smoothTime);

			transform.position = new Vector3 (numPos, 0, transform.position.z);
		}

    }

}
