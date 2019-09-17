using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Camera_Switch : MonoBehaviour {

    public GameObject _Camera_One;
    public GameObject _Camera_Two;

   // AudioListener _Camera_One_AL;
    //AudioListener _Camera_Two_AL;
    // Use this for initialization
    void Start()
    {
      //  _Camera_One_AL = _Camera_One.GetComponent<AudioListener>();
        //_Camera_One_AL = _Camera_One.GetComponent<AudioListener>();
        //Camera Position Set
        _Camera_Pos_Change(PlayerPrefs.GetInt("CameraPosition"));
    }

	// Update is called once per frame
	void Update () {
        _Switch_Camera();
	}

    void _Switch_Camera()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.T))
        {
            _Camera_Change_Counter();
        }
    }
    void _Camera_Change_Counter()
    {
        int _Cam_Pos_Counter = PlayerPrefs.GetInt("CameraPosition");
        _Cam_Pos_Counter++;
        _Camera_Pos_Change(_Cam_Pos_Counter);
    }
    void _Camera_PosM()
    {
        _Camera_Change_Counter();
    }

    void _Camera_Pos_Change(int _Cam_Pos)
    {
     if(_Cam_Pos > 1)
        {
            _Cam_Pos = 0;
        }
        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", _Cam_Pos);
        //set cam pos 1
        if(_Cam_Pos == 0)
        {
            _Camera_One.SetActive(true);
          

            _Camera_Two.SetActive(false);
        }
        if (_Cam_Pos == 1)
        {
            _Camera_One.SetActive(false);
          

            _Camera_Two.SetActive(true);
         
        }
    }
}
