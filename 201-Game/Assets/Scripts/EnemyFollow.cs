using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject projectilePrefab;
    private float startDelay = 1;
    private float spawnInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating(nameof(fire), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {       
        enemy.SetDestination(player.position);
    }

    void fire()
    {
       
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
