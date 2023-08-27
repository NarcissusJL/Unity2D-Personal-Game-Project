using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Function: allow player collide with coins(player's Capsule Collider)
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
      {
        SoundManager.Play_Collect(); // play coin collect audio effect 
        UI_Coins.currentCoinNum += 1; // current Coin Number(text in script "UI_Coins") update 1
        Destroy(gameObject);  // then the coin disappear
      }
    }
}
