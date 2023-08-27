using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_MovingPlatform : MonoBehaviour
{

    public float moveSpeed;
    public float waitTime;

    public Transform[] position;

    private int factor; // key element to decide the moving position range.
    private Transform playerTransform; //player its own position

    // Start is called before the first frame update
    void Start()
    {
      factor = 1;
      playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent; // set parent of player
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, position[factor].position, moveSpeed * Time.deltaTime);
      if(Vector2.Distance(transform.position, position[factor].position) < 0.01f)  // if distance between current position and target position < 0.01
      {

        if(waitTime < 0.0f)
        {
          if(factor == 0)
          {
            factor = 1;
          }
          else
          {
            factor = 0;
          }
          waitTime = 0.5f;
        }
        else
        {
          waitTime -= Time.deltaTime;
        }

      }
    }

    // Function: allow player can stand on the moving platform
    void OnTriggerEnter2D(Collider2D other) // player get on the platform
    {
      if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
      {
        other.gameObject.transform.parent = gameObject.transform;  //set player as a child object of the moving platform
      }
    }

    void OnTriggerExit2D(Collider2D other) // player get off the platform
    {
      if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
      {
        other.gameObject.transform.parent = playerTransform;  //revert process of (set player as a child object of the moving platform)
      }
    }
}
