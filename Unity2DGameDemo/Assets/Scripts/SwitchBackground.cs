using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{

    public GameObject image_01;  // background 1
    public GameObject image_02; // background 2
    public float switchTime;   // background switch wait time (white background duration time)

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.H))
      {
        animator.SetBool("ToWhite", true);   // set bool "ToWhite" to true
        Invoke("SwitchImage", switchTime);   // Activate SwitchImage function
      }
    }

    // Function: Switch background image
    void SwitchImage()
    {
      image_01.SetActive(false);
      image_02.SetActive(true);
    }
}
