using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bomb : MonoBehaviour
{

    public Vector2 initialSpeed;
    public float explodeDelay; // after this time the bomb explode
    public float destroyTime;
    public float hitboxTime; // how much time after, generate the explosion hitbox range
    public float soundEffectTime; // how much time after, generate the explosion sound effect
    public GameObject explosionRange;

    private Rigidbody2D rb2d;

    private Animator bombAnim;

    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
      bombAnim = GetComponent<Animator>();

      rb2d.velocity = transform.right * initialSpeed.x + transform.up * initialSpeed.y; // assign the velocity (simulation action of throwing the bomb)
      Invoke("Explode", explodeDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function: Bomb explode animation
    void Explode()
    {
      bombAnim.SetTrigger("Explode");
      Invoke("ExplosionRange", hitboxTime);
      Invoke("SoundEffect", soundEffectTime);
      Invoke("destroyBomb", destroyTime);

    }

    void ExplosionRange()
    {
      Instantiate(explosionRange, transform.position, Quaternion.identity); // generate a explosion at the point
    }
    // destroy game object after explode
    void destroyBomb()
    {
      Destroy(gameObject);
    }
    // initialize sound soundEffect
    void SoundEffect()
    {
      SoundManager.Play_explosion();
    }

}
