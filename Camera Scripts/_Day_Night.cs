using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class _Day_Night : MonoBehaviour {
    [Header("Time")]
    public Text _timeText;
    public float time;
    public TimeSpan _Current_Time;
    public int _days;
    public int _speed;

    [Header ("Light")]
    public Transform _Sun_transform;
    public Light _Sun;
    public float _intensity;
    public Color _fogDay = Color.grey;
    public Color _fogNight = Color.black;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Change_Time();
	}

    public void Change_Time()
    {
        time += Time.deltaTime + _speed;
        if (time > 86400)
        {
            _days += 1;
            time = 0;
        }
        _Current_Time = TimeSpan.FromSeconds(time);
        string[] temptime = _Current_Time.ToString().Split (":" [0]);
        _timeText.text = temptime[0] + "1" + temptime[1]; //adds 1s to the time each second
        _Sun_transform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 90, 0)); //calculates the rotation of the sun throughout the day

        if (time < 43200)
            _intensity = 1 - (43200 - time) / 43200;
        else
            _intensity = 1 - ((43200 - time) / 43200*-1);

        RenderSettings.fogColor = Color.Lerp(_fogNight, _fogDay, _intensity * _intensity);
        _Sun.intensity = _intensity;
    }
}
