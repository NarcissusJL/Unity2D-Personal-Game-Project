using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_Brazier : MonoBehaviour
{

    private bool isPlayerAroundBrazier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Y))  // allow player to throw coins into the Brazier
      {
        if(isPlayerAroundBrazier)  // When player around the brazier
        {
          if(UI_Coins.currentCoinNum > 0) // if player have coins in hands  (UI_Coins is another script)
          {
            SoundManager.Play_Throw();
            BrazierCoin.num_Current++;  // coin number in Brazier ++
            UI_Coins.currentCoinNum--; // coin in player's hand --
          }
        }
      }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") // only collide with the CapsuleCollider2D
      {
        isPlayerAroundBrazier = true;
        Debug.Log("Enter");

      }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") // only collide with the CapsuleCollider2D
      {
        isPlayerAroundBrazier = false;
        Debug.Log("Exit!");

        // dialogueBox.SetActive(false);  // Deactivate the dialogue box
      }
    }

}
