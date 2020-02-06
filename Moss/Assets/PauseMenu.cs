using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //For checking if the game is paused or not
    public GameObject pauseMenuUI; //Game object for the UI of the pause menu , so you can activate it or disable it
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Checks if the player is pressing the escape key
        {
            if(GameIsPaused) //if GameIsPaused = true
            { // Checks if the game is already paused if so un pause the game 
                Resume(); //Run resume function
            }else
            { // Checks if the game is not paused if so pause the game#
                Pause(); // Run pause function
            }
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false); // Make the UI go away
        Time.timeScale = 1f; //Un pauses the game , starts the frames back up
        GameIsPaused = false; //Changes the state of the game to un paused
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Make the UI Appear
        Time.timeScale = 0f; // Slows down the game to the point where nothing is moving
        GameIsPaused = true; // Changes the game state to paused
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Changes the time scale to 1 so the game runs again , also prevents menu from bugging out
        SceneManager.LoadScene("Menu"); //Loads the menu scene
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game"); 
        Application.Quit(); //Quits the application
    }
}
