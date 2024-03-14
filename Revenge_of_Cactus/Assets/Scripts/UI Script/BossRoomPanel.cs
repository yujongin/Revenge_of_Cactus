using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossRoomPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Succeed_Image;
    public GameObject Monster;
    public GameObject myPamel;
    public List<GameObject> Monsters = new List<GameObject>();
    public List<GameObject> Panels = new List<GameObject>();

    public Text monster_information_explain;
    int monster_HP;
    int monster_damage;
    int monster_defence;
    int monster_second_damage;

    void Start()
    {
        
        for(int i = 0; i<Monster.transform.childCount; i++)
        {
            Monsters.Add(Monster.transform.GetChild(i).gameObject);
            Panels.Add(myPamel.transform.GetChild(i).gameObject);
            if (i > 0)
            {
                myPamel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt(this.name + "_clear") >=1)
        {
            Succeed_Image.SetActive(true);
        }
        else
        {
            Succeed_Image.SetActive(false);
        }



    }
    private void Update()
    {
        if (this.name == "Slime")
        {            
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[1]);
        }
        if (this.name == "TurtleShell")
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[2]);
        }
        if (this.name == "Skeleton")
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[3]);
        }
        if (this.name == "Golem")
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[4]);
        }
    }


    public void StartBtn()
    {
        //SceneManager.LoadScene(훈련장 씬);
        PlayerPrefs.SetString("Monster_Name",this.name);
        PlayerPrefs.SetString("Battle_OR_Exercise", "Battle");
        PlayerPrefs.SetString("", "");
        SoundManager.instance.PlayClickSound();
        LoadingSceneController.LoadScene("Demo");
/*        SceneManager.LoadScene("Demo");*/
        
    }

    public void ChoiceMonster()
    {
        for (int i = 0; i < Monster.transform.childCount; i++)
        {
            if(Monsters[i].name == this.name)
            {
                Monsters[i].SetActive(true);


                monster_power(Monsters[i].name);
                monster_information_explain.text = string.Format(" 체력 : {0}       방어력 : {1}  \n약공격력 : {2}     강공격력 : {3}", monster_HP, monster_defence, monster_damage, monster_second_damage);
            }
            else
            {
                Monsters[i].SetActive(false);
            }
        }
    }

    public void OpenRoom(int ClearCount, GameObject BossRoom)
    {     
        if (ClearCount >= 1)
        {
            BossRoom.SetActive(true);
        }
    }

    public void monster_power(string name)
    {
        switch(name)
        {
            case "Slime":
                monster_HP = 100 + PlayerPrefs.GetInt("Slime_clear") * 20;
                monster_damage = 5 + PlayerPrefs.GetInt("Slime_clear");
                monster_defence = 1 + PlayerPrefs.GetInt("Slime_clear");
                monster_second_damage = 6 + PlayerPrefs.GetInt("Slime_clear");
                break;
            case "TurtleShell":
                monster_HP = 200 + PlayerPrefs.GetInt("TurtleShell_clear") * 20;
                monster_damage = 4 + PlayerPrefs.GetInt("TurtleShell_clear");
                monster_defence = 4 + PlayerPrefs.GetInt("TurtleShell_clear");
                monster_second_damage = 5 + PlayerPrefs.GetInt("TurtleShell_clear");
                break;
            case "Skeleton":
                monster_HP = 300 + PlayerPrefs.GetInt("Skeleton_clear") * 20;
                monster_damage = 12 + PlayerPrefs.GetInt("Skeleton_clear");
                monster_defence = 8 + PlayerPrefs.GetInt("Skeleton_clear");
                monster_second_damage = 14 + PlayerPrefs.GetInt("Skeleton_clear");
                break;
            case "Golem":
                monster_HP = 400 + PlayerPrefs.GetInt("Golem_clear") * 20;
                monster_damage = 20 + PlayerPrefs.GetInt("Golem_clear");
                monster_defence = 20 + PlayerPrefs.GetInt("Golem_clear");
                monster_second_damage = 22 + PlayerPrefs.GetInt("Golem_clear");
                break;
            case "EvilMage":
                monster_HP = 500 + PlayerPrefs.GetInt("EvilMage_clear") * 20;
                monster_damage = 30 + PlayerPrefs.GetInt("EvilMage_clear");
                monster_defence = 25 + PlayerPrefs.GetInt("EvilMage_clear");
                monster_second_damage = 40 + PlayerPrefs.GetInt("EvilMage_clear");
                break;
        }
            
        
    }
}
