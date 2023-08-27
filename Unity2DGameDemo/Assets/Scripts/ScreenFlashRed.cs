using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlashRed : MonoBehaviour
{

    public Image image;
    public Color color_Flash;
    private Color color_Default;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        color_Default = image.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function: player get hit, screen flash red for a period of time.
    public void RedFlash()
    {
      StartCoroutine(Flash());
    }

    IEnumerator Flash() // Ienumerator for "RedFlash()".
    {
      image.color = color_Flash;
      yield return new WaitForSeconds(time);
      image.color = color_Default;

    }
}
