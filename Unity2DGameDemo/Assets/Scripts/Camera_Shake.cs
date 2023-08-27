using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public Animator mainCamAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Camera shake function, set the trigger "shake"
    public void CamShake()  //set public to allow other scripts to access
    {
      mainCamAnim.SetTrigger("Shake");
    }
}
