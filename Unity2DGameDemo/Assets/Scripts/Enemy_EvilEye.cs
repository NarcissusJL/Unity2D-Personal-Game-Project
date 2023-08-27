using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_EvilEye : Enemy  // inherit from Enemy abstract class.
{

    public float speed;
    public float startTime;
    private float waitTime; //duration time after object reach a position before go to next.

    public Transform movePos;
    public Transform topRightPos;
    public Transform bottomLeftPos;

    // Start is called before the first frame update
    public void Start()
    {
      base.Start(); // call start from base class
      waitTime = startTime;
      movePos.position = randomPos();
    }

    // Update is called once per frame
    public void Update()
    {
      base.Update(); // call update from base class

      transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime); // move

      if(Vector2.Distance(transform.position, movePos.position) < Mathf.Epsilon) //detect whether the object reach the random position
      {
        if(waitTime <= 0) // if object wait for enough time, go to next position
        {
          movePos.position = randomPos();
          waitTime = startTime;     // reset waitTime
        }
        else{
          waitTime -= Time.deltaTime;
        }


      }
    }


    // generate new random position
    Vector2 randomPos()
    {
      Vector2 rPos = new Vector2(Random.Range(bottomLeftPos.position.x, topRightPos.position.x), Random.Range(bottomLeftPos.position.y, topRightPos.position.y));
      return rPos;
    }




}
