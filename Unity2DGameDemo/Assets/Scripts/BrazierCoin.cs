using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrazierCoin : MonoBehaviour
{

    public Text coinNumText;
    public static int num_Current;
    public static int num_Max;

    private Image brazierBar;

    // Start is called before the first frame update
    void Start()
    {
      brazierBar = GetComponent<Image>();
      num_Current = 0;
      num_Max = 99;
    }

    // Update is called once per frame
    void Update()
    {
        brazierBar.fillAmount = (float)num_Current / (float)num_Max; // change the barfill as the coin changes
        coinNumText.text = num_Current.ToString() + "/" + num_Max.ToString();  // update text on the bar
    }
}
