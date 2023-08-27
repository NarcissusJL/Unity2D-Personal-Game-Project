using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/////////////////////Function: Allow object's UI text can anchor on the object////////////////////////////

public class UI_Controller : MonoBehaviour
{

    public RectTransform UI_Object;
    public RectTransform Canvas_Rect;
    public Transform sacrificialBrazierPos;  // sacrificialBrazier's World position

    public float x_offset; // allow UI to change x axis when anchored to some object
    public float y_offset; // allow UI to change y axis when anchored to some object

    public Text coinNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Vector2 viewportPos = Camera.main.WorldToViewportPoint(sacrificialBrazierPos.position);  // assign camera's viewport to this variable  (sacrificialBrazier's World position -> viewport position)
      Vector2 worldObjectScreenPos = new Vector2((viewportPos.x * Canvas_Rect.sizeDelta.x) -
                                                  (Canvas_Rect.sizeDelta.x * 0.5f) + x_offset,
                                                  (viewportPos.y * Canvas_Rect.sizeDelta.y) -
                                                  (Canvas_Rect.sizeDelta.y * 0.5f) + y_offset);
      UI_Object.anchoredPosition = worldObjectScreenPos;
    }
}
