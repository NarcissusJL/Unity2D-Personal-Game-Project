using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public float durationTime;
    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject,durationTime);  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
