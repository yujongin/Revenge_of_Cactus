using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyChanger : MonoBehaviour
{
    public Text Money;

    void Update()
    {
        Money.text = PlayerPrefs.GetInt("Coin_Total").ToString();
    }
}
