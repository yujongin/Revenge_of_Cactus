using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_check : MonoBehaviour
{
    private Animator monster_ani;
    string monster_name;
    
    bool monster_pattern_on_off;

    public GameObject Slime_magic;
    public GameObject Tuttle_magic;
    public GameObject Skeleton_magic;
    public GameObject Golem_magic;
    public GameObject Boss_magic;
    

    void Start()
    {
        monster_name = PlayerPrefs.GetString("Monster_Name");
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        monster_pattern_on_off =  monster_ani.GetBool("pattern");
        if(monster_pattern_on_off)
        {
           switch(monster_name)
            {
                case "Slime":
                    Slime_magic.SetActive(true);
                    break;
                case "TurtleShell":
                    Tuttle_magic.SetActive(true);
                    break;
                case "Skeleton":
                    Skeleton_magic.SetActive(true);
                    break;
                case "Golem":
                    Golem_magic.SetActive(true);
                    break;
                case "EvilMage":
                    Boss_magic.SetActive(true);
                    break;
            }
        }
        if(!monster_pattern_on_off)
        {
            Slime_magic.SetActive(false);
            Tuttle_magic.SetActive(false);
            Skeleton_magic.SetActive(false);
            Golem_magic.SetActive(false);
            Boss_magic.SetActive(false);
        }
    }
}
