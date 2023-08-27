using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENV_RoadSign : MonoBehaviour
{

    public GameObject dialogueBox;
    public Text dialogueText;
    public string roadSignText;
    private bool isPlayerAroundSign; // detect whether player collide with the road sign or not.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.E) && isPlayerAroundSign)  // player collide
      {
        dialogueText.text = roadSignText; // text of dialogue box will be shown as the roadSignText of RoadSign
        dialogueBox.SetActive(true);  //Activate the dialogue box
      }
    }
    // Function: player collide with the road sign
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") // only collide with the CapsuleCollider2D
      {
        // Debug.Log("Enter");
        isPlayerAroundSign = true;
      }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") // only collide with the CapsuleCollider2D
      {
        // Debug.Log("Exit!");
        isPlayerAroundSign = false;
        dialogueBox.SetActive(false);  // Deactivate the dialogue box
      }
    }
}
