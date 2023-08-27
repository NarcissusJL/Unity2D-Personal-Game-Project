// Overall abstract class for enemies
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;

    public float flashTime;
    public GameObject bloodEffect;

    public GameObject dropRewards; // drop coins after death
    public GameObject floatNumEffect; // float damage number effect

    private SpriteRenderer sr;
    private Color originColor;
    private Player_Health playerHealth; //access to script "Player_Health".

    // Start is called before the first frame update
    public void Start() // need to be public to be called from other scipts
    {
      playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>(); //Find script "Player_Health"

      sr = GetComponent<SpriteRenderer>();
      originColor = sr.color;
    }

    // Update is called once per frame
    public void Update() // need to be public to be called from other scipts
    {
        if(health <= 0)
        {
          Instantiate(dropRewards, transform.position, Quaternion.identity);  // drop coin after death
          Destroy(gameObject);
        }
    }

    // Calculate the damage taken by the player
    public void takeDamage(int damage)
    {
      SoundManager.Play_EnemyHurt();
      GameObject Go = Instantiate(floatNumEffect, transform.position, Quaternion.identity) as GameObject; // initiate floatNumEffect function
      // get the child object FloatFonts of FloatFontsBase, then assign actual damage value number to the text under TextMesh
      Go.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

      health -= damage;
      colorFlicker(flashTime);
      Instantiate(bloodEffect, transform.position, Quaternion.identity);  // blood drop effect

      GameController.cameraShaking.CamShake();  // everytime enemy injured, camera shakes
    }

    // enemy hit feedback color flicker(set duration time)
    void colorFlicker(float time)
    {
      sr.color = Color.red;
      Invoke("colorReset",time);
    }
    // enemy hit feedback color flicker(reset to default color)
    void colorReset()
    {
      sr.color = originColor;
    }

    //Check whether enemy collide with the player
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") //if collide with player's Capsule Collider 2D
      {
        if(playerHealth != null)
        {
          playerHealth.playerGetHit(damage);  //this "damage" is enemy's damage declared above
        }
      }
    }
}
