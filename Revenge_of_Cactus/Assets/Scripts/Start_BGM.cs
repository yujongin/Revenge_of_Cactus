using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Start_BGM : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetInt("game_start_bgm_on_off", 1);
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        if (PlayerPrefs.GetInt("game_start_bgm_on_off") == 0)
        {
            Destroy(gameObject);
        }
        try
        {

        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

    }
}
