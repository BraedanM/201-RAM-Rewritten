using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class EnemyProjectile : MonoBehaviour
{
    public int projectileType;
    
    private void OnTriggerEnter(Collider other)
    {
        //depending on what number is assigned will determine the damage of the projectile
        if (other.CompareTag("Player"))//if the object in contact is tagged as player do this
        {
            int dmg = 0;

            switch (projectileType)//depending on what number do this amount of damage
            {
                case 1:
                    dmg = 3; 
                    break;
                case 2:
                    dmg = 5; 
                    break;
                case 3:
                    dmg = 10; 
                    break;
            }
        //damage player for this amount
            GameManager.Gamemanager.playerHealth.DmgPlayer(dmg);
            Destroy(gameObject);//destory the object when it after all this
        
        }
    }
}
