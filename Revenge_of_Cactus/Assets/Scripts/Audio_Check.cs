using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Check : MonoBehaviour
{
    public Animator User_ani;
    bool onoff = true;

    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        BGM_start();
    }

    public void BGM_start()
    {
        if (PlayerPrefs.GetString("Battle_OR_Exercise") == "Battle")
        {
            switch (PlayerPrefs.GetString("Monster_Name"))
            {
                case "Slime":
                    BGM.clip = BGMList[0].audio;
                    BGM.Play();
                    break;
                case "TurtleShell":
                    BGM.clip = BGMList[0].audio;
                    BGM.Play();
                    break;
                case "Skeleton":
                    BGM.clip = BGMList[1].audio;
                    BGM.Play();
                    break;
                case "Golem":
                    BGM.clip = BGMList[2].audio;
                    BGM.Play();
                    break;
                case "EvilMage":
                    BGM.clip = BGMList[3].audio;
                    BGM.Play();
                    break;
            }
        }
        if(PlayerPrefs.GetString("Battle_OR_Exercise") == "Exercise")
        {
            BGM.clip = BGMList[6].audio;
            BGM.Play();
        }
    }
    private void Update()
    {
        if(User_ani.GetBool("user_die") && onoff)
        {
            BGM.clip = BGMList[5].audio;
            BGM.Play();
            onoff = false;
        }
        if(User_ani.GetBool("user_Victory") && onoff)
        {
            BGM.clip = BGMList[4].audio;
            BGM.Play();
            onoff = false;
        }
    }
}
