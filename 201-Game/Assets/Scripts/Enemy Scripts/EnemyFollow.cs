using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//uses ai to avoid obstacles and follow player

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
        player = GameObject.FindWithTag("Player").transform;//finds the object with player tag
        InvokeRepeating(nameof(Fire), startDelay, spawnInterval);//fire projectile repeatedly
    }

    void Update()
    {       
        enemy.SetDestination(player.position);//targets the players position
    }

    void Fire()
    {   
        Instantiate(projectilePrefab, transform.position, transform.rotation);//spawns the enemy projectile
    }
}
