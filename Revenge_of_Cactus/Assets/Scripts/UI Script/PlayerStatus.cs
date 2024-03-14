using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public const int BasicAbility = 1;

    public int a = 0;
    public Text PointText1;
    public Text PointText2;
    public Text BTPText;
    public int BattlePoint;

    public Text PlayerStatusText;
    public int PlayerAbility;

    

    void Start()
    {    
       
        BTPText.text = PlayerPrefs.GetInt("BattlePoint").ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        //능력치를 Playerpref에서 받아와야함
        if (PlayerPrefs.GetInt(this.name) == 0)
        {
            PlayerPrefs.SetInt(this.name, BasicAbility);
        }
        PlayerStatusText.text = PlayerPrefs.GetInt(this.name).ToString();
        BattlePoint = int.Parse(BTPText.text);
    }

    public void AddPoint()
    {
        if (BattlePoint > 0)
        {
            a++;
            PointText1.text = "(" + "+" + a.ToString() + ")";
            PointText2.text = a.ToString();
            BattlePoint--;
            BTPText.text = BattlePoint.ToString();
            SoundManager.instance.PlayClickSound();
        }
        
    }
    public void MinusPoint()
    {       
        if (a <= 0)
        {
            a = 0;
        }
        else
        {
            a--;
            BattlePoint++;
            BTPText.text = BattlePoint.ToString();
            SoundManager.instance.PlayClickSound();
        }
        PointText1.text = "(" + "+" + a.ToString() + ")";
        PointText2.text = a.ToString();
    }
    public void ApplyPoint()
    {
        PlayerAbility = int.Parse(PlayerStatusText.text);
        PlayerAbility = PlayerAbility + a;
        a = 0;
        PlayerStatusText.text = PlayerAbility.ToString();
        PointText2.text = a.ToString();
        PointText1.text = "(" + "+" + a.ToString() + ")";
        PlayerPrefs.SetInt(this.name, PlayerAbility);
        PlayerPrefs.SetInt("BattlePoint", BattlePoint);
        int t = PlayerPrefs.GetInt(this.name);
        Debug.Log(this.name+":"+t);
        SoundManager.instance.PlayClickSound();
    }
}
