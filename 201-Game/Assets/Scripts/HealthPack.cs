using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//when touched by another object
    {

        if (other.CompareTag("Player")) //if the collided object is tagged as player do this
        {
            GameManager.Gamemanager.playerHealth.HealPlayer(20);//heals the players health by adding 20 to current health
            Destroy(gameObject);//destory the object after as it is a one time use
        }

            
    } 
}
