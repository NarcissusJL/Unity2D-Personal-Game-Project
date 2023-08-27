using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coins : MonoBehaviour
{

    public int initialCoinNum;
    public Text coinNum;

    public static int currentCoinNum;

    // Start is called before the first frame update
    void Start()
    {
      currentCoinNum = initialCoinNum;

    }

    // Update is called once per frame
    void Update()
    {
      coinNum.text = currentCoinNum.ToString();
    }
}
