using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class demo_clear_scene_MG : MonoBehaviour
{
    public Sprite[] Img = new Sprite[6];
    public Image img1;
    string clear_monster;


    // Start is called before the first frame update
    void Start()
    {
        clear_monster = PlayerPrefs.GetString("Monster_Name");
        if (clear_monster == "Slime")
        {
            PlayerPrefs.SetString("temp1", "0");
            img1.sprite = Img[0];
        }
        if (clear_monster == "TurtleShell")
        {
            img1.sprite = Img[1];
        }
        if (clear_monster == "Skeleton")
        {
            img1.sprite = Img[2];
        }
        if (clear_monster == "Golem")
        {
            img1.sprite = Img[3];
        }
        if (clear_monster == "EvilMage")
        {
            img1.sprite = Img[4];
            PlayerPrefs.SetString("temp1", "1");
        }


    }
    public void onclick_village()
    {
        if(PlayerPrefs.GetString("temp1") == "0")
        {
            LoadingSceneController.LoadScene("Village");
        }

        if (PlayerPrefs.GetString("temp1") == "1")
        {
            img1.sprite = Img[5];
            PlayerPrefs.SetString("temp1", "0");
        }
        
        
    }
}
