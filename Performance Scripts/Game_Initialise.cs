using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Initialise : MonoBehaviour {
    public static bool game_playing;

	// Use this for initialization
	void Start () {
        game_playing = true;
        Data_Management._data_management._currentScore = 0;
        Data_Management._data_management.LoadData(); //loads previous high score

    }

    // Update is called once per frame
    void Update () {
		
	}
}
