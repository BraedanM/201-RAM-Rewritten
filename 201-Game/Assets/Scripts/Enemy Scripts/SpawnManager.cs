using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject healthPrefab;
    //for game difficulty enemy spawn rate increases over time
    public float initialSpawnInt = 6f;//the start rate
    public float intervalDecrease = 4f; // interval decreases by this value after each spawn
    public float lowestSpawnInt = 0.5f; //lowest rate the interval gets to.
    private float spawnRangeX = 30;
    private float spawnPosZ = 35;
    private float spawnRangeX2 = -30;
    private float spawnPosZ2 = -35;   
    private float currentSpawnInterval;
    private float timeSinceLastSpawn;

    //for some reason when lots of objects are created the games speeds up which causes wall collisions to stop working
    //and I can't figure out how to fix it
  
    void Start()
    {
        StartCoroutine(SpawnHealthPackDelay(60f));//used to wait to spawn the health packs
        currentSpawnInterval = initialSpawnInt;
        timeSinceLastSpawn = 0f;
    }

    IEnumerator SpawnHealthPackDelay(float delay)//spawns after delay
    {
        yield return new WaitForSeconds(delay);
        SpawnHealthPack();
    }


    void FixedUpdate()
    {//the mess of code to try and stop the game speeding up
        timeSinceLastSpawn += Time.deltaTime;
        //decreases the spawn intervals to increase game difficulty
        if (timeSinceLastSpawn >= currentSpawnInterval)
        {
            SpawnRandomEnemy();
            SpawnRandomEnemy2();
            timeSinceLastSpawn = 0f;
            currentSpawnInterval = Mathf.Max(lowestSpawnInt, currentSpawnInterval - intervalDecrease);//decreases the current interval until it hits the limit
            //Debug.Log("Current Spawn Interval: " + currentSpawnInterval);
        }
    }

   void SpawnRandomEnemy()
    {//spawn enemies along a line at random positions set by the range
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
        //pick at random from the array of emenmy prefabs
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
            enemyPrefabs[enemyIndex].transform.rotation);
    }

    void SpawnRandomEnemy2()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX2, spawnRangeX2), 1, spawnPosZ2);

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
            enemyPrefabs[enemyIndex].transform.rotation);
    }

    void SpawnHealthPack()
    {//spawns 2 health packs at 2 locations
        Vector3 spawnPos = new Vector3(35, 0.1f, -35);
        Instantiate(healthPrefab, spawnPos, healthPrefab.transform.rotation);

        Vector3 spawnPos2 = new Vector3(-35, 0.1f, 35);
        Instantiate(healthPrefab, spawnPos2, healthPrefab.transform.rotation);
    }
}
