using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : Enemy
{
    public float detectRadius;
    public float speed;

    private Transform playerTrans;
    // Start is called before the first frame update
    public void Start()
    {
      base.Start(); // call start from base class
      playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // get player's position
    }

    // Update is called once per frame
    public void Update()
    {
      base.Update(); // call update from base class
      if(playerTrans != null)
      {
        float distance = (transform.position - playerTrans.position).sqrMagnitude; // distance between enemy and player
        if(distance < detectRadius) // if player in the radius
        {
          transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, speed * Time.deltaTime); // enemy move towards player's position
        }
      }
    }
}
