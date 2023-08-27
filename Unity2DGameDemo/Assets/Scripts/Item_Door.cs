using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item_Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Function: player get in the door and change scene
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") //if collide with player's Capsule Collider 2D
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Gets current active scene, then switch to next scene
      }
    }

}
