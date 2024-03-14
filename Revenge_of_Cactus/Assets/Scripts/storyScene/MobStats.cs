using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobStats : MonoBehaviour
{
    //slime
    int M_Helth_S = 100;
    int M_Damage_S = 1;
    int M_Defence_S = 1;
    int M_Scond_Damage_S = 2;

    //turtle
    int M_Helth_T = 150;
    int M_Damage_T = 2;
    int M_Defence_T = 2;
    int M_Scond_Damage_T = 3;

    //skeleton
    int M_Helth_Sk = 200;
    int M_Damage_Sk = 3;
    int M_Defence_Sk = 3;
    int M_Scond_Damage_Sk = 4;

    //Golem
    int M_Helth_G = 250;
    int M_Damage_G = 4;
    int M_Defence_G = 4;
    int M_Scond_Damage_G = 5;

    //Mage
    int M_Helth_M = 300;
    int M_Damage_M = 5;
    int M_Defence_M = 5;
    int M_Scond_Damage_M = 6;

    // Start is called before the first frame update
    public void SlimeStat()
    {
        PlayerPrefs.SetInt("Monster_Health", M_Helth_S);
        PlayerPrefs.SetInt("Monster_Damage", M_Damage_S);
        PlayerPrefs.SetInt("Monster_Defence", M_Defence_S);
        PlayerPrefs.SetInt("Monster_Second_damage", M_Scond_Damage_S);
        PlayerPrefs.Save();
    }
    public void TurtleStat()
    {
        PlayerPrefs.SetInt("Monster_Health", M_Helth_T);
        PlayerPrefs.SetInt("Monster_Damage", M_Damage_T);
        PlayerPrefs.SetInt("Monster_Defence", M_Defence_T);
        PlayerPrefs.SetInt("Monster_Second_damage", M_Scond_Damage_T);
        PlayerPrefs.Save();
    }
    public void SkeletonStat()
    {
        PlayerPrefs.SetInt("Monster_Health", M_Helth_Sk);
        PlayerPrefs.SetInt("Monster_Damage", M_Damage_Sk);
        PlayerPrefs.SetInt("Monster_Defence", M_Defence_Sk);
        PlayerPrefs.SetInt("Monster_Second_damage", M_Scond_Damage_Sk);
        PlayerPrefs.Save();
    }
    public void GolemStat()
    {
        PlayerPrefs.SetInt("Monster_Health", M_Helth_G);
        PlayerPrefs.SetInt("Monster_Damage", M_Damage_G);
        PlayerPrefs.SetInt("Monster_Defence", M_Defence_G);
        PlayerPrefs.SetInt("Monster_Second_damage", M_Scond_Damage_G);
        PlayerPrefs.Save();
    }
    public void MageStat()
    {
        PlayerPrefs.SetInt("Monster_Health", M_Helth_M);
        PlayerPrefs.SetInt("Monster_Damage", M_Damage_M);
        PlayerPrefs.SetInt("Monster_Defence", M_Defence_M);
        PlayerPrefs.SetInt("Monster_Second_damage", M_Scond_Damage_M);
        PlayerPrefs.Save();
    }
    public void Load()
    {
    }

    // Update is called once per frame
    /*    void Update()
        {
            Debug.Log(stat1);
            Debug.Log(stat2);
            Debug.Log(stat3);
        }*/
}
