using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Manager : MonoBehaviour {

    public GameObject[] platform_Prefab; //creates an array
    private Transform player_transform;
    private float spawnZ = -16.0f;//helps to find where exactly we will spawn the tiles
    private float platform_length = 400.0f;//length of a tile
    private int amount_of_platforms = 7;//the amount of tiles allowed to be shown on screen
    private float safe_zone = 800.0f;//waits 15 meters before deleting the object
    private int lastPrefabIndex = 0;
    private List<GameObject> active_Platforms;

    // Use this for initialization
    private void Start()
    {
        active_Platforms = new List<GameObject>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;//finds player

        for (int i = 0; i < amount_of_platforms; i++) //spawns tile in relation to the amount of platforms on the screen
        {
            if (i < 2)

                Spawn_Platform(0); //spawns the first listed bridge each time 
            else
                Spawn_Platform(); //random from here on out
        }
    }
	
	// Update is called once per frame
	private void Update () {
		if (player_transform.position.z - safe_zone > (spawnZ - amount_of_platforms * platform_length)) //spawns and deletes platforms depending on the players position - everytime a platofmr is spawned, another one is deleted
        {
            Spawn_Platform();
            Delete_Platform();
        }
	}
    private void Spawn_Platform(int prefabIndex = -1)
    {
        GameObject go;
            if(prefabIndex == -1)
        {
            go = Instantiate(platform_Prefab[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(platform_Prefab[prefabIndex]) as GameObject;
        }
       // go = Instantiate(platform_Prefab[0]) as GameObject;
        go.transform.SetParent(transform); //every platform will appear under the parent within the hierarchy for the sake of organisation
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += platform_length;
        active_Platforms.Add(go);
    }

    private void Delete_Platform()
    {
        Destroy(active_Platforms[0]);
        active_Platforms.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (platform_Prefab.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex== lastPrefabIndex)
        {
            randomIndex = Random.Range(0, platform_Prefab.Length);//chooses a random prefab each time.
        }
         lastPrefabIndex = randomIndex;
            return randomIndex;
    }
}
