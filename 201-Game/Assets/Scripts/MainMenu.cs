using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;
    public GameObject story;
    public GameObject tutorial;
 
    public void NewGame()
    {
        tutorial.SetActive(true); //sets the tutorial window to appear before a new game is loaded     
    }

    public void StartGame()
    {
        tutorial.SetActive(false);//closed the tutorial window when the user clicks to proceed
        Time.timeScale = 1f;//had issues where returning to the main menu and starting a new game had the game frozen
        SceneManager.LoadScene(newGameScene);//loads into the game scene
    }

    public void QuitGame()
    {
        Application.Quit();//quits the app on click
    }

    public void StoryWindow()
    {
        story.SetActive(true);//story window is made active on click
    }

    public void BackToMenu()//used for back buttons
    {//makes any active window false
        story.SetActive(false);
        tutorial.SetActive(false);

    }
}
