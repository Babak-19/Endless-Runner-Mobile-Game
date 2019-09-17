using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour {
    public GameObject restart_UI;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            PlayerDies();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Coin")
        {
            Data_Management._data_management._coins_collected++;
            Data_Management._data_management._currentScore++; //increase coin collection
            //power up
            Destroy(col.gameObject);
            Debug.Log("Coin collected!");   
        }
    }

    void PlayerDies()
    {
        //play death audio
        Data_Management._data_management.SaveData();
        Data_Management._data_management._currentScore = 0;
        //    UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        restart_UI.gameObject.SetActive(true);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Player_Controls>().enabled = false;
        GetComponent<Player_Movement>().enabled = false;
        GetComponent<ParticleSystem>().Play();
    }
}
