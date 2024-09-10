using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject gameOver;

    void Update()
    {
        GameOver();
        //for testing
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.Gamemanager.playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.Gamemanager.playerHealth.Health);
        }*/
    }
    public void GameOver()
    {
        //when the players health gets to 0 or below, freeze the game and show game over window
        if (GameManager.Gamemanager.playerHealth.currentHealth <= 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
    public void BackToMenu()
    {
        //return time to flowing, remove window and send back to main menu
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        SceneManager.LoadScene("Main Menu");

    }

}

