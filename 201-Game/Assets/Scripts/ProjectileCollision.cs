using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other) //only destroys enemies
    {
        if (!other.CompareTag("Walls") && !other.CompareTag("Projectile") && !other.CompareTag("Player"))
        {
            Destroy(gameObject);//destroys both objects
            Destroy(other.gameObject);
        }

    }
}
