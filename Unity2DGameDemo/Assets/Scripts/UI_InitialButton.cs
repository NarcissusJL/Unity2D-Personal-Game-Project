///////////////////////////////////////////////
// Function: make sure player can select menu button using keyboard
///////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InitialButton : MonoBehaviour
{

    private GameObject lastSelectedButton;
    // Start is called before the first frame update
    void Start()
    {
      lastSelectedButton = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
      if(EventSystem.current.currentSelectedGameObject == null)  // if no button is selected
      {
        EventSystem.current.SetSelectedGameObject(lastSelectedButton); // select the last selected button.
      }
      else
      {
        lastSelectedButton = EventSystem.current.currentSelectedGameObject;
      }
    }
}
