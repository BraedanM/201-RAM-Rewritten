using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class EnemyProjectile : MonoBehaviour
{
    public int projectileType;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            int dmg = 0;

           
            switch (projectileType)
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

           
            GameManager.Gamemanager.playerHealth.DmgPlayer(dmg);
            Destroy(gameObject);
        
        }
    }
}
