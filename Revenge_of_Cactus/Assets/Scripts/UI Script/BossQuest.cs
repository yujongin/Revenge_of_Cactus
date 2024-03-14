using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuest : MonoBehaviour
{
    public GameObject proceeding;
    public GameObject accept;
    public GameObject complete;
    public GameObject finish;

    public GameObject myPanel;
    public List<GameObject> Panels = new List<GameObject>();

    public bool Quest;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < myPanel.transform.childCount; i++)
        {
            Panels.Add(myPanel.transform.GetChild(i).gameObject);
            if (i > 0)
            {
                myPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //날짜가 바뀌면 다시 수락버튼 켜짐
        if (System.DateTime.Now.ToString("dd") != PlayerPrefs.GetString(this.name + "Clearday"))
        {
            accept.SetActive(true);
            proceeding.SetActive(false);
            complete.SetActive(false);
            finish.SetActive(false);
            Quest = false;
        }
        //퀘스트 끝나면 완료 텍스트 보여주기
        else if (PlayerPrefs.GetString(this.name + "_Quest") == "Finish")
        {
            accept.SetActive(false);
            proceeding.SetActive(false);
            complete.SetActive(false);
            finish.SetActive(true);
        }

        //진행중이면 껐다 켜도 진행중이기
        if (PlayerPrefs.GetString(this.name + "_Quest") == "Proceeding")
        {
            Quest = true;
            PlayerPrefs.SetString(this.name + "_Quest", "Proceeding");
            accept.SetActive(false);
            proceeding.SetActive(true);
            complete.SetActive(false);
            finish.SetActive(false);
        }

        //처음꺼 깨면 다음꺼 나오기
        if (this.name == "Slime"&& PlayerPrefs.GetString(this.name)==this.name)
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[1]);
        }
        if (this.name == "TurtleShell" && PlayerPrefs.GetString(this.name) == this.name)
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[2]);
        }
        if (this.name == "Skeleton" && PlayerPrefs.GetString(this.name) == this.name)
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[3]);
        }
        if (this.name == "Golem" && PlayerPrefs.GetString(this.name) == this.name)
        {
            OpenRoom(PlayerPrefs.GetInt(this.name + "_clear"), Panels[4]);
        }

        //클리어 타임이 높아지면 완료 버튼 띄우기
        if (Quest&&PlayerPrefs.GetInt(this.name + "ClearTime") < PlayerPrefs.GetInt(this.name + "_clear"))
        {
            accept.SetActive(false);
            proceeding.SetActive(false);
            complete.SetActive(true);
            finish.SetActive(false);
        }
    }

    public void AcceptBtn()
    {
        Quest = true;
        PlayerPrefs.SetString(this.name + "_Quest", "Proceeding");
        accept.SetActive(false);
        proceeding.SetActive(true);
        complete.SetActive(false);
        finish.SetActive(false);
        PlayerPrefs.SetString(this.name + "Clearday", System.DateTime.Now.ToString("dd"));
        PlayerPrefs.SetInt(this.name + "ClearTime", PlayerPrefs.GetInt(this.name + "_clear"));
        Debug.Log(PlayerPrefs.GetInt(this.name + "ClearTime"));
    }

    public void CompleteBtn()
    {
        Quest = false;
        PlayerPrefs.SetString(this.name + "_Quest", "Finish");
        PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + 3000);
        PlayerPrefs.SetInt("BattlePoint", PlayerPrefs.GetInt("BattlePoint") + 3);
        accept.SetActive(false);
        proceeding.SetActive(false);
        complete.SetActive(false);
        finish.SetActive(true);
        PlayerPrefs.SetString(this.name, this.name);
        PlayerPrefs.SetString(this.name + "Clearday", System.DateTime.Now.ToString("dd"));
    }

    public void OpenRoom(int ClearCount, GameObject BossRoom)
    {
        if (ClearCount >= 1)
        {
            BossRoom.SetActive(true);
        }
    }
}
