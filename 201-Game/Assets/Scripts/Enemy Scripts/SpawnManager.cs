using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
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

    //for some reason when lots of objects are created the games speeds up
    //and I can't figure out how to fix it
  
    void Start()
    {
        currentSpawnInterval = initialSpawnInt;
        timeSinceLastSpawn = 0f;
    }


    
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= currentSpawnInterval)
        {
            SpawnRandomEnemy();
            SpawnRandomEnemy2();
            timeSinceLastSpawn = 0f;
            currentSpawnInterval = Mathf.Max(lowestSpawnInt, currentSpawnInterval - intervalDecrease);
            Debug.Log("Current Spawn Interval: " + currentSpawnInterval);
        }
    }

   void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);

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
}
