using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_Succed : MonoBehaviour
{
    string clear_monster;
    public void go_back_village()
    {
        clear_monster = PlayerPrefs.GetString("Monster_Name") + "_clear";
        if (PlayerPrefs.GetInt(clear_monster) == 1)
        {
            SceneManager.LoadScene("demo_clear_scene");
        }
        else
        {
            SceneManager.LoadScene("Village");
        }
        
    }
}
