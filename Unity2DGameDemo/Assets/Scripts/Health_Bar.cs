using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{

    public Text health_Num;
    public static int healthCurrent;
    public static int health_Max;

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        // healthCurrent = health_Max;
    }

    // Update is called once per frame
    void Update()
    {
      healthBar.fillAmount = (float)healthCurrent / (float)health_Max;
      health_Num.text = healthCurrent.ToString() + "/" + health_Max.ToString();

    }
}
