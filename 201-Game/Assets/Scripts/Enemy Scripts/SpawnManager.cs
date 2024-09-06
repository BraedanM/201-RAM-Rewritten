using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    //for game difficulty enemy spawn rate increases over time
    public float initialSpawnInt = 6f;//the start rate
    public float intervalDecrease = 0.025f; // interval decreases by this value after each spawn
    public float lowestSpawnInt = 0.5f; //lowest rate the interval gets to.
    private float spawnRangeX = 30;
    private float spawnPosZ = 35;
    private float spawnInterval = 4f;
    private float spawnRangeX2 = -30;
    private float spawnPosZ2 = -35;   
    private float currentSpawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnInterval = initialSpawnInt;
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            InvokeRepeating(nameof(SpawnRandomEnemy), 0, spawnInterval);
            InvokeRepeating(nameof(SpawnRandomEnemy2), 0, spawnInterval);
            yield return new WaitForSeconds(currentSpawnInterval);

            
            currentSpawnInterval = Mathf.Max(lowestSpawnInt, currentSpawnInterval - intervalDecrease);
        }
    }

    // Update is called once per frame
    void Update()
    {     
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
