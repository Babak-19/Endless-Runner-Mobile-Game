using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    public int playerSpeed = 100;
	
	void FixedUpdate () {
        gameObject.transform.Translate(Vector3.forward * playerSpeed * Time.fixedDeltaTime);
	}
}
