using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script created from youtube tutorial
//Dani Krossing, May 29th 2022, https://www.youtube.com/watch?v=9i0UGVUKiaE&t=687s
public class GameManager : MonoBehaviour
{
    public static GameManager Gamemanager { get; private set; }
    public PlayerHealth playerHealth = new PlayerHealth(100, 100);//new player health object for the player
    void Awake()
    {
        //makes sure another gamemanager is not created and deletes it if so.
        if (Gamemanager != null && Gamemanager != this)
        {
            Destroy(this);
        }
        else
        {
            Gamemanager = this;
        }
    }

   
}
