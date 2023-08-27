using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioSource audioS;
    // Coin:
    public static AudioClip coin_Collect;
    public static AudioClip coin_Throw;

    // Chest:
    public static AudioClip chest_Open;

    // Bomb:
    public static AudioClip bomb_Explosion;

    // Attack: J
    public static AudioClip wieldSword;

    // Attack: K
    public static AudioClip flySword;

    // Player Hurt
    public static AudioClip playerGetHurt;

    // Player Death
    public static AudioClip playerDead;

    // Enemies Hurt
    public static AudioClip enemyHurt;


    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();

        coin_Collect = Resources.Load<AudioClip>("collect");
        coin_Throw = Resources.Load<AudioClip>("ThrowCoin");

        chest_Open = Resources.Load<AudioClip>("openChest");

        bomb_Explosion = Resources.Load<AudioClip>("explosion");

        wieldSword = Resources.Load<AudioClip>("swordAttack");

        flySword = Resources.Load<AudioClip>("flySword");

        playerGetHurt = Resources.Load<AudioClip>("playerHurt");

        playerDead = Resources.Load<AudioClip>("playerDeath");

        enemyHurt = Resources.Load<AudioClip>("enemyHurt");
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Function: play coin collect audio effect
    public static void Play_Collect()
    {
      audioS.PlayOneShot(coin_Collect);
    }
    // Function: play coin throw audio effect
    public static void Play_Throw()
    {
      audioS.PlayOneShot(coin_Throw);
    }
    // Function: play open chest sound effect
    public static void Play_openChest()
    {
      audioS.PlayOneShot(chest_Open);
    }
    // Function: play bomb explosion sound effect
    public static void Play_explosion()
    {
      audioS.PlayOneShot(bomb_Explosion);
    }
    // Function: play wield sword sound effect
    public static void Play_WieldSword()
    {
      audioS.PlayOneShot(wieldSword);
    }
    // Function: play fly sword sound effect
    public static void Play_FlySword()
    {
      audioS.PlayOneShot(flySword);
    }
    // Function: play player death SFX
    public static void Play_Death()
    {
      audioS.PlayOneShot(playerDead);
    }
    // Function: play player Hurt SFX
    public static void Play_playerHurt()
    {
      audioS.PlayOneShot(playerGetHurt);
    }
    // Function: play enemy Hurt SFX
    public static void Play_EnemyHurt()
    {
      audioS.PlayOneShot(enemyHurt);
    }
}
