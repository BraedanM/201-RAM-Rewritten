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
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void NewGame()
    {
        tutorial.SetActive(true);      
    }

    public void StartGame()
    {
        tutorial.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(newGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StoryWindow()
    {
        story.SetActive(true);
    }

    public void BackToMenu()
    {
        story.SetActive(false);
        tutorial.SetActive(false);

    }
}
