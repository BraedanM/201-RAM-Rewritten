using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{  
    public GameObject pauseMenu;

    void Update()
    {
        //when user hits the escape key the time is set to zero to freeze the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if the user presses the escape key again instead of the resume button
            //it checks if its paused and resumes if so
            if(Time.timeScale == 0)
                ResumeGame();
            else
                Pausegame();
            
        }    
    }

   public void Pausegame()
    {
        pauseMenu.SetActive(true);//make pause menu visible
        Time.timeScale = 0f; //freeze game
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);//make menu invisible and rume time/game
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;//allow time to flow
        SceneManager.LoadScene("Main Menu");//load main menu scene
    }
}
