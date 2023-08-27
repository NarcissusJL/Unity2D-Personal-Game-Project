using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_FlySword : MonoBehaviour
{

    public int damage;
    public float speed;

    public float flyDistance;

    private Rigidbody2D rb2d;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed; // give a rightward velocity
        startPosition = transform.position; // document current position as start position
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPosition).sqrMagnitude; // distance between current position and start position
        if(distance > flyDistance) // if out of flying range
        {
          Destroy(gameObject);
        }
    }
    // allow enemy collide with the sword
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Enemies"))
      {
        other.GetComponent<Enemy>().takeDamage(damage); // call the function "takeDamage" of Enemy script
      }
    }
}
