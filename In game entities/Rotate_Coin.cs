using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Coin : MonoBehaviour {

    public int rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate (Vector3.down * rotationSpeed * Time.fixedDeltaTime);
	}
}
