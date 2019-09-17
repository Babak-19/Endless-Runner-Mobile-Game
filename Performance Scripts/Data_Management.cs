using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Data_Management : MonoBehaviour {

    public static Data_Management _data_management;
    public int _high_score;
    public int _coins_collected;
    public int _currentScore;
	
    void Awake()
    {
        if(_data_management == null)
        {
            DontDestroyOnLoad(gameObject);
            _data_management = this;
        }
        else if (_data_management != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	public void SaveData () {
        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); // creates the file
        gameData data = new gameData();
        data._high_score = _high_score; //replaces the current highscore with a new one
        data._coins_collected = _coins_collected; //saves the amount of coins collected
        binForm.Serialize (file, data);
        file.Close();
        Debug.Log("Saved");
	}

    public void LoadData()
    {
        if (File.Exists (Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open); //opens the file
            gameData data = (gameData)binForm.Deserialize(file);//gets the data
            file.Close();//closes the file
            _high_score = data._high_score; //displays the current high score
            _coins_collected = data._coins_collected;
            Debug.Log("Loaded");
        }
    }

    [Serializable]
    class gameData
    {
        public int _high_score;
        public int _coins_collected;
    }
}
