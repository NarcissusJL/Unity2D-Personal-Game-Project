using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_Spike : MonoBehaviour
{

    public int damage;  // spike's damage

    private Player_Health playerHealth; //Get access to script "Player_Health".
    // Start is called before the first frame update
    void Start()
    {
      playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>(); //Get access to script "Player_Health".
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check if the collider of spikes collide with player or not
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D") //prevent collide with both capsule and box therefore get damage twice
      {
        playerHealth.playerGetHit(damage);
      }
    }
}
