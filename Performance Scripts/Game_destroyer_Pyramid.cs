using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_destroyer_Pyramid : MonoBehaviour
{
    private float time_till_destroy = 30.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        time_till_destroy -= Time.deltaTime;
        if (time_till_destroy < 0.01 && Game_Initialise.game_playing == true) // destroys game objects after 15 seconds
        {
            Destroy(gameObject);

        }
    }
}
