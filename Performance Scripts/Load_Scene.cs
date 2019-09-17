using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {

public void Load_to_scene (string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
