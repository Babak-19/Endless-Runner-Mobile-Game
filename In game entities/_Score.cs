using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Score : MonoBehaviour {

    public GameObject scoreUI;
    public GameObject highScoreUI;
	
	// Update is called once per frame
	void Update () {
        if(Data_Management._data_management._currentScore > Data_Management._data_management._high_score)
        {
            Data_Management._data_management._high_score = Data_Management._data_management._currentScore; //makes the highscore the current score
        }

	     scoreUI.GetComponent<Text>().text = ("Score: " + Data_Management._data_management._currentScore.ToString());
         highScoreUI.GetComponent<Text>().text = ("High Score: " + Data_Management._data_management._high_score.ToString());

	}
}
