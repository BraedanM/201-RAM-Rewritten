using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script created from youtube tutorial
//Dani Krossing, May 29th 2022, https://www.youtube.com/watch?v=9i0UGVUKiaE&t=687s
public class PlayerBehaviour : MonoBehaviour
{
    public GameObject gameOver;
    void Start()
    {

    }


    void Update()
    {
        GameOver();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.Gamemanager.playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.Gamemanager.playerHealth.Health);
        }
    }
    //damages the player with the amount by passing to game manager
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.Gamemanager.playerHealth.DmgPlayer(dmg);
    }
    //heals the player with the amount by passing to game manager
    private void PlayerHeal(int healing)
    {
        GameManager.Gamemanager.playerHealth.HealPlayer(healing);
    }

    public void GameOver()
    {
        if (GameManager.Gamemanager.playerHealth.currentHealth <= 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        SceneManager.LoadScene("Main Menu");

    }

}

