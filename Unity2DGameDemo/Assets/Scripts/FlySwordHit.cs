using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySwordHit : MonoBehaviour
{

    public GameObject FlySwordObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.K))
      {
        SoundManager.Play_FlySword();
        Instantiate(FlySwordObject, transform.position, transform.rotation); // generate a flying sword at position
      }

    }

    // void ThrowSword()
    // {
    //   Instantiate(FlySwordObject, transform.position, transform.rotation); // generate a flying sword at position
    // }
}
