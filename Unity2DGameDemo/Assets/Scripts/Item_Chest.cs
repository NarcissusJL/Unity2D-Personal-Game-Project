using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Chest : MonoBehaviour
{

    private bool isOpened;
    private bool canOpen;

    private Animator chestAnim;

    public GameObject chestCoin;
    public float coinDropDelay; // after this time the coin drops from the chest

    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.I))    // press I to open the chest box
      {
        if(canOpen && !isOpened)   // if the chest is not opened before and can open
        {
          SoundManager.Play_openChest(); // play sound effect
          chestAnim.SetTrigger("Open");
          isOpened = true;
          // Instantiate(chestCoin, transform.position, Quaternion.identity);  // generate coins after open the chest
          Invoke("coinDrop", coinDropDelay);  // after coinDropDelay time, function coinDrop is called
        }
      }
    }

    void coinDrop()
    {
      Instantiate(chestCoin, transform.position, Quaternion.identity); // generate coins after open the chest
    }

    // Player collide with chest box
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
      {
        canOpen = true;
      }
    }
    // Player exit chest box
    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
      {
        canOpen = false;
      }
    }
}
