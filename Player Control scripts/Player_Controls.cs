using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {
    //public static float boostFuel = 1.5f;
    //public float fuelComsumptionRate;
    //public float boostForce = 10.0f;
    
    [Header("Jumping")]
    public Vector3 _Jump_height = new Vector3(0.0f, 5.0f, 0.0f);
    public Rigidbody  rb;
    public float _jumpForce = 2.0f;
    public float _jumpLimit;
    [Header("Ground Checking")]
    public bool isGrounded;
    public float _distance;
    public LayerMask _layer;

    [Header("Lights")]
    public bool lightOn;
    public GameObject Light1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lightOn = false;
        Light1.SetActive(false);
    }

 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // rb.velocity = _Jump_height;
            rb.AddForce(_Jump_height * _jumpForce, ForceMode.Impulse);
            Debug.Log("jump!");
            isGrounded = false;
        }

        if (transform.position.y >= _jumpLimit)
        {
            rb.velocity = -Vector3.up; // Sets a jump height limit to prevent the player from jumping too high
        
        }
        _Stats();

        if (Input.GetKeyDown(KeyCode.A) && lightOn == false)
        {
            lightOn = true;
            Light1.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.A) && lightOn == true)
        {
            lightOn = false;
            Light1.SetActive(false);

        }
    }


    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void _Stats()
    {
        if (isGrounded)
            _distance = 40.0f;
        else
            _distance = 40.0f;

        if (Physics.Raycast(transform.position - new Vector3(0, 0.85f, 0), -transform.up, _distance, _layer))
            isGrounded = true;
        else
            isGrounded = false;
    }
    //void BoostForward()
    //{
    //    boostFuel -= fuelComsumptionRate * Time.deltaTime;
    //    print("boostfuel = " + boostFuel);  
    //    transform.GetComponent<Rigidbody>().AddForce(new Vector3(45, boostForce,0), ForceMode.Force );
    //}
}
