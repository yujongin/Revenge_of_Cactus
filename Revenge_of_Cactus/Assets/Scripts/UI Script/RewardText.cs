using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardText : MonoBehaviour
{
    public Text gold;
    public Text battlePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = PlayerPrefs.GetInt(this.name + "Gold_Reward").ToString();
        battlePoint.text = PlayerPrefs.GetInt(this.name + "BattlePoint_Reward").ToString();
    }
}
