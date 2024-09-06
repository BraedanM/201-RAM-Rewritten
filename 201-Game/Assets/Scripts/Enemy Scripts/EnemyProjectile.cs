using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //when its hits the player it reduces the player health and destroys itself
            GameManager.Gamemanager.playerHealth.DmgPlayer(2);
            Destroy(gameObject);
        }
    }
}
