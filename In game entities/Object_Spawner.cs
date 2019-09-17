using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    [Header("Coins")]
    public GameObject[] coins;
    private float coinSpawnTimer = 1.0f;

    [Header("Enemies")]
    public GameObject enemy;
    private float enemySpawnTimer = 1.0f;

    [Header("General")]
    public GameObject player;
    private float platformSpawnTimer =0.01f;
    public GameObject[] platform;

    [Header("Pyramid")]
    private float pyramidSpawnTimer = 5.0f;
    public GameObject[] pyramid;

    [Header("Trees")]
    public GameObject [] trees;
    private Vector3 tree_spawn_locations;
    private float tree_start_spawn = 20;
    private float treeSpawnTimer = 0.05f;

    void start()
    {
        tree_spawn_locations.x = -300;
        Spawn_start_trees();
       
    }
    // Update is called once per frame
    void Update()
    {
        coinSpawnTimer -= Time.deltaTime;
        enemySpawnTimer -= Time.deltaTime;
        treeSpawnTimer -= Time.deltaTime;
        platformSpawnTimer -= Time.deltaTime;
        pyramidSpawnTimer -= Time.deltaTime;
        if (coinSpawnTimer < 0.001f)// && Game_Initialise.game_playing == true)
        {
            SpawnCoins();

         //   Debug.Log("Coins have spawned!");
        }
        if (enemySpawnTimer < 0.001f) //&& Game_Initialise.game_playing == true)
        {
          //  SpawnEnemy(); 

         //   Debug.Log("An enemy has spawned!");
        }
        if (treeSpawnTimer < 0.001f)// && Game_Initialise.game_playing == true)
        {
            SpawnTrees();
         //   Debug.Log("Trees!");
        }
        if (platformSpawnTimer < 0.001f)// && Game_Initialise.game_playing == true)
        {
            SpawnPlatform();
        //    Debug.Log("Platforms!");
        }
        if (pyramidSpawnTimer < 0.001f)// && Game_Initialise.game_playing == true)
        {
            SpawnPyramid();
         //   Debug.Log("Platforms!");
        }

    }
    void Spawn_start_trees()
    {
        while (tree_start_spawn > 0)
        {
            GameObject newTree;
            newTree = Instantiate(trees[(Random.Range(1, trees.Length))], new Vector3(tree_spawn_locations.x - 2000, -10, player.transform.position.z - 1000), Quaternion.identity);
            tree_spawn_locations.x = tree_spawn_locations.x + 5;
            newTree.transform.localScale = new Vector3(6, 6, 6);
            treeSpawnTimer--;
        }
    }

    void SpawnCoins()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(player.transform.position.x + 80, Random.Range(2,8) + 30, player.transform.position.z +700), Quaternion.Euler(0,0,0)); //instantiates one of the coin prefabs by randomly choosing one of the prefabs
        coinSpawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy;
        newEnemy = Instantiate(enemy, new Vector3(player.transform.position.x , Random.Range(20,88) , player.transform.position.z + 1000), Quaternion.Euler (0,90,0));
        newEnemy.transform.localScale = new Vector3(1, 1, 1); //sets the size and scale of the enemy once spawned.
        enemySpawnTimer = Random.Range(5, 10); //will spawn an enemy between 1 and 10s
    }
    void SpawnTrees()
    {
        GameObject newTree;
       newTree =  Instantiate(trees[(Random.Range(0, trees.Length))], new Vector3(player.transform.position.x - Random.Range(200, 600), -10, player.transform.position.z + 1500), Quaternion.identity);
       newTree.transform.localScale = new Vector3(6, 6, 6);
        treeSpawnTimer = 0.05f;

    }

    void SpawnPlatform()
    {
        GameObject newPlatform;
        newPlatform = Instantiate(platform[(Random.Range(0, platform.Length))], new Vector3(player.transform.position.x - 2000, -10, player.transform.position.z +2000), Quaternion.identity);
        newPlatform.transform.localScale = new Vector3(6000, 0, 10000);
        platformSpawnTimer = 10.0f;
    }

    void SpawnPyramid()
    {
        GameObject newPyramid;
        newPyramid = Instantiate(pyramid[(Random.Range(0, pyramid.Length))], new Vector3(player.transform.position.x - Random.Range(2000, 6000), -10, player.transform.position.z + 6600), Quaternion.identity);
        newPyramid.transform.localScale = new Vector3(50, 50, 50);
        pyramidSpawnTimer = 5.0f;
    }
}
