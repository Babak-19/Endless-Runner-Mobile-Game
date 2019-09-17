using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
	// Use this for initialization

	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = player.position + offset; //sets the camera off of the players position
      
	}
}
