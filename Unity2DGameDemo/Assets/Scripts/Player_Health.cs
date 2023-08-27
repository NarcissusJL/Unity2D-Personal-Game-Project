using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health;
    public int flashNum; // # of flashes
    public float flashTime;// flash duration time
    public float destroyTime; //animation time before player be destroyed
    public float PC2DTime; //PC2D exist CD

    private Renderer myRender;
    private Animator death_Anim;

    private ScreenFlashRed SFR; // access to ScreenFlashRed script

    private Rigidbody2D RB2D;
    private PolygonCollider2D PC2D;

    // Start is called before the first frame update
    void Start()
    {
      Health_Bar.health_Max = health;
      Health_Bar.healthCurrent = health;// set the max value of health bar and player health.

      myRender = GetComponent<Renderer>();
      death_Anim = GetComponent<Animator>();

      SFR = GetComponent<ScreenFlashRed>(); // get access to ScreenFlashRed script

      RB2D = GetComponent<Rigidbody2D>();
      PC2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function: player get hit
    public void playerGetHit(int damage)
    {
      SoundManager.Play_playerHurt();
      SFR.RedFlash();
      health -= damage;

      if(health < 0)
      {
        health = 0;  // avoid the healthbar display current value less than 0.
      }

      Health_Bar.healthCurrent = health; //allow healthCurrent in script "Health_Bar" can reduce after player get hit.
      if(health <= 0)
      {
        GameController.isPlayerDead = true;  // player is dead.

        SoundManager.Play_Death();

        RB2D.velocity = new Vector2(0,0); // set velocity to 0 after death(body won't fly away after death)

        death_Anim.SetTrigger("Die");
        Invoke("PlayerDestroy", destroyTime); //after a period of time, the object got destroyed.

      }
      PlayerFlashRed(flashNum, flashTime); // call the PlayerFlashRed function

      ////////////////////////////////// Allow multiple times of damages when player on spikes //////////////////////////////
      PC2D.enabled = false;  //For spikes to detect collision with player
      StartCoroutine(PC2D_Exist());
    }

    IEnumerator PC2D_Exist()  //PC2D hitbox exist time CD
    {
      yield return new WaitForSeconds(PC2DTime);
      if(health > 0)
      {
        PC2D.enabled = true;
      }
    }
    ////////////////////////////////// Allow multiple times of damages when player on spikes //////////////////////////////



    // After death, make time to allow death animation to play
    void PlayerDestroy()
    {
      Destroy(gameObject);
    }

    // after player get hit, player flashes red(injury effect)
    void PlayerFlashRed(int num, float seconds)
    {
      StartCoroutine(Flashes(num, seconds));
    }

    IEnumerator Flashes(int num, float seconds)
    {
      for(int i = 0; i < num * 2; i++)
      {
        myRender.enabled = !myRender.enabled;
        yield return new WaitForSeconds(seconds);
      }
      myRender.enabled = true;
    }
}
