using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
  // start play and load first level scene
  public void StartPlay()
  {
    SceneManager.LoadScene(1);
  }
  // quit the game and the scene
  public void QuitGame()
  {
    Application.Quit();
  }
}
