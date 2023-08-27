using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        if(isPaused)
        {
          Resume();
        }
        else
        {
          Pause();
        }
      }
    }

    // Function: Resume
    public void Resume()
    {
      pauseMenu.SetActive(false);
      Time.timeScale = 1.0f; // restore game speed
      isPaused = false;
    }
    // Function: Return to main menu
    public void MainMenu()
    {
      isPaused = false;
      Time.timeScale = 1.0f;
      SceneManager.LoadScene("StartMenu"); // load the Main Menu Scene
    }
    // Function: Pause the game
    public void Pause()
    {
      pauseMenu.SetActive(true);
      Time.timeScale = 0.0f;  // freeze game time
      isPaused = true;
    }
    //Function: Quit the game
    public void Quit()
    {
      Application.Quit();
    }
}
