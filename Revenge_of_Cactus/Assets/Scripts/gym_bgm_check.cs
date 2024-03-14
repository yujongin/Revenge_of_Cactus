using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gym_bgm_check : MonoBehaviour
{
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
        if (BGMList.Length > 0)
        {
            PlayBGM(BGMList[0].name);
        }
        BGM_start();
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }
    public void BGM_start()
    {
        if (PlayerPrefs.GetString("Succeed_OR_Fail") == "Succeed")
        {
            PlayBGM("succed");
        }

    }
}
