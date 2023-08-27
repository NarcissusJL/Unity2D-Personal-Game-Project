using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int damage;

    private Animator anim_Attack;
    private PolygonCollider2D Att_Hitbox;
    // Start is called before the first frame update
    void Start()
    {
      anim_Attack = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
      Att_Hitbox = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(GameController.isPlayerDead == false)  // player can do following if he is alive.(Prevent player from doing actions if dead)
      {
        attack();
      }
    }

    //Function: Player Attack
    void attack()
    {
      if(Input.GetButtonDown("Attack"))
      {
        SoundManager.Play_WieldSword();
        anim_Attack.SetTrigger("Attack");
        StartCoroutine(attHitboxDuration());
      }
    }

    //Set the att hitbox duration in the animation frames
    IEnumerator attHitboxDuration()
    {
      yield return new WaitForSeconds(0.2f);
      Att_Hitbox.enabled = true;
      StartCoroutine(disableHitbox());
    }

    //set attack hitbox existing time in the frames
    IEnumerator disableHitbox()
    {
      yield return new WaitForSeconds(0.2f);
      Att_Hitbox.enabled = false;
    }

    // Check whether player collide with the enemies
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Enemies"))
      {
        other.GetComponent<Enemy>().takeDamage(damage);    //call the takeDamage function of Enemy abstract class.
      }
    }
}
