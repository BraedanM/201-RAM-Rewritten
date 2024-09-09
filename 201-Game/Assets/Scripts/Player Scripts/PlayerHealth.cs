using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script created from youtube tutorial
//Dani Krossing, May 29th 2022, https://www.youtube.com/watch?v=9i0UGVUKiaE&t=687s
public class PlayerHealth
{
    private int currentMaxHealth;
    public int currentHealth;
    

    //Properties
    public int Health //returns health and assigns health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth //returns max health and assigns max health
    {
        get
        {
            return currentMaxHealth;
        }
        set
        {
            currentMaxHealth = value;
        }
    }

    //constructor
    public PlayerHealth(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }
    //takes in damage amount and substracts from current health
    public void DmgPlayer(int dmgAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmgAmount;
        }
      
    }
    //takes in the integer amount and if health is not zero adds to current health
    public void HealPlayer(int healAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth += healAmount;
        }
        //to make sure player health does not go over the max
        if(currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }

    }

}
