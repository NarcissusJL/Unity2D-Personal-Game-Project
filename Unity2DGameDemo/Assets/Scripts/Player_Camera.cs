using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Transform target;
    public float smoothing; //camera smoothing

    public Vector2 limitMin;
    public Vector2 limitMax; // min and max limitation for camera movement range.

    // Start is called before the first frame update
    void Start()
    {
      GameController.cameraShaking = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<Camera_Shake>();   //find tag CaneraShake's script "Camera_Shake" so that we can call this in every script everywhere.
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()  // called after Update is called
    {
      if(target != null)// if target still exists
      {
        if(transform.position != target.position)// if camera position and target position is not the same
        {
          Vector3 targetPos = target.position;

          targetPos.x = Mathf.Clamp(targetPos.x, limitMin.x, limitMax.x);
          targetPos.y = Mathf.Clamp(targetPos.y, limitMin.y, limitMax.y); // restrain camera movement range

          transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
      }
    }

    // Function: set camera limit
    public void LimitCamera(Vector2 minPos, Vector2 maxPos)
    {
      limitMin = minPos;
      limitMax = maxPos;
    }
}
