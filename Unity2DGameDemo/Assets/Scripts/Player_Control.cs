using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float ladderClimbSpeed;

    public float ResetPlayerLayerTime; // player get off the OneWayPlatform after a period of time, then reset plyaer's layer to its own.

    private Rigidbody2D myRigidbody;
    private Animator player_Anim;
    private BoxCollider2D playerFeet;
    private bool onGround;
    private bool canDoubleJump;
    private bool onOneSidePlatform;

    private bool onLadder;
    private bool LadderClimbing;
    private bool Jumping;
    private bool Falling;
    private bool DJumping;
    private bool DFalling;

    private float playerGravity;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player_Anim = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRigidbody.gravityScale; // cache original gravity value (Used to restore gravity)


    }

    // Update is called once per frame
    void Update()
    {
      if(GameController.isPlayerDead == false)  // player can do following if he is alive.(Prevent player from doing actions if dead)
      {
        MirrorAnim();
        Run();
        Jump();
        groundCheck();
        ladderCheck();
        // attack();
        animShift();
        OneSidePlatformCheck();
        ClimbLadders();
      }

    }
    // Define player on the ground
    void groundCheck()
    {
      onGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                 playerFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
                 playerFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
      onOneSidePlatform = playerFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
      // Debug.Log(onGround);
    }
    // Define player on ladder
    void ladderCheck()
    {
      onLadder = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    // Mirror the Animation when character running left
    void MirrorAnim()
    {
      bool playerMoveOnX = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
      if (playerMoveOnX)
      {
        if (myRigidbody.velocity.x > 0.01f)
        {
          transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else
        {
          transform.localRotation = Quaternion.Euler(0,180,0);
        }
      }
    }

    // Define character's running direction and speed
    void Run()
    {
      float Player_Dir = Input.GetAxis("Horizontal");
      Vector2 player_Speed = new Vector2(Player_Dir * runSpeed, myRigidbody.velocity.y);
      myRigidbody.velocity = player_Speed;

      bool playerMoveOnX = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
      player_Anim.SetBool("isRun", playerMoveOnX);
    }

    // Define character's jump direction, speed and double jump
    void Jump()
    {
      if(Input.GetButtonDown("Jump"))
      {
        if(onGround)
        {
          player_Anim.SetBool("isJump", true);
          Vector2 jump_Speed = new Vector2(0.0f, jumpSpeed);
          myRigidbody.velocity = Vector2.up * jump_Speed;
          canDoubleJump = true;
        }
        else
        {
          if(canDoubleJump){
            player_Anim.SetBool("isDJump", true);
            Vector2 doubleJump_Speed = new Vector2(0.0f, doubleJumpSpeed);
            myRigidbody.velocity = Vector2.up * doubleJump_Speed;
            canDoubleJump = false;
          }
        }

      }
    }
    // Function: player climb the ladders
    void ClimbLadders()
    {
      if(onLadder) // if on the ladder
      {
        float Y_speed = Input.GetAxis("Vertical"); // define and get speed on Y axis
        if(Y_speed > 0.5f || Y_speed < -0.5f) // if speed on Y axis > 0.5f or < 0.5f
        {
          player_Anim.SetBool("isClimb", true);
          myRigidbody.gravityScale = 0.0f; // when player on the ladder, remove the gravity sothat player can stop on the ladder
          myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Y_speed * ladderClimbSpeed);
        }
        else // consider the situation when player don't climb, just passing by the ladder
        {
          if(Jumping || Falling || DJumping || DFalling)
          {
            player_Anim.SetBool("isClimb", false);
          }
          else   // when player stop in front of the ladder but not climbing
          {
            player_Anim.SetBool("isClimb", false);
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f); // set player's speed on Y axis to 0.
          }
        }
      }
      else // if not on the ladder, reset everything to normal
      {
        player_Anim.SetBool("isClimb", false);
        myRigidbody.gravityScale = playerGravity;
      }

    }



    /////////////////////////////////////////////////////////////////////Function: Player Attack
    // void attack()
    // {
    //   if(Input.GetButtonDown("Attack")){
    //     if(!player_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
    //       player_Anim.SetTrigger("Attack");
    //     }
    //   }
    // }





    //Detect the motion of the player and switch the animation
    void animShift()
    {
      player_Anim.SetBool("isIdle", false);
      if(player_Anim.GetBool("isJump"))
      {
        if(myRigidbody.velocity.y < 0.0f){
          player_Anim.SetBool("isJump", false);
          player_Anim.SetBool("isFall", true);
        }
      }
      else if(onGround){
        player_Anim.SetBool("isFall", false);
        player_Anim.SetBool("isIdle", true);
      }
      if(player_Anim.GetBool("isDJump"))
      {
        if(myRigidbody.velocity.y < 0.0f){
          player_Anim.SetBool("isDJump", false);
          player_Anim.SetBool("isDFall", true);
        }
      }
      else if(onGround){
        player_Anim.SetBool("isDFall", false);
        player_Anim.SetBool("isIdle", true);
      }
    }

    // Function: press "s" to allow player get off the OneSidePlatform
    void OneSidePlatformCheck()
    {

      if(onGround && gameObject.layer != LayerMask.NameToLayer("Player"))// Debug: avoid the situation when player get off the OneWayPlatform but the layer didn't reset
      {
        gameObject.layer = LayerMask.NameToLayer("Player");
      }

      float Y_speed = Input.GetAxis("Vertical"); // define and get speed on Y axis
      if(onOneSidePlatform && Y_speed < -0.1f)
      {
        // In project setting collision part, since layer OneWayPlatform cannot collide with itself, we change player layer to OneWayPlatform.
        gameObject.layer = LayerMask.NameToLayer("OneWayPlatform"); //change player layer
        Invoke("ResetPlayerLayer", ResetPlayerLayerTime);
      }
    }
    //Reset player's layer after OneSidePlatformCheck() change the player's layer
    void ResetPlayerLayer()
    {
      if(!onGround && gameObject.layer != LayerMask.NameToLayer("Player"))
      {
        gameObject.layer = LayerMask.NameToLayer("Player");
      }
    }

    // Check the status of the player(cache bool data)
    void PlayerStatusCheck()
    {
      Jumping = player_Anim.GetBool("isJump");
      Falling = player_Anim.GetBool("isFall");
      DJumping = player_Anim.GetBool("isDJump");
      DFalling = player_Anim.GetBool("isDFall");
      LadderClimbing = player_Anim.GetBool("isClimb");
    }





}
