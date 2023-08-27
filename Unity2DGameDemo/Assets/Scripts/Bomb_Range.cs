using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Range : MonoBehaviour
{

    public int damage;
    public float destroyTime;

    private Player_Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>(); // access to player health script
        Destroy(gameObject,destroyTime); // destroy explosion range after explode
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function: player and enemy all can be damaged by the explosion
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Enemies"))
      {
        other.GetComponent<Enemy>().takeDamage(damage);    //call the takeDamage function of Enemy abstract class.
      }
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") //if collide with player's Capsule Collider 2D
      {
        if(playerHealth != null)
        {
          playerHealth.playerGetHit(damage);
        }
      }
    }
}
