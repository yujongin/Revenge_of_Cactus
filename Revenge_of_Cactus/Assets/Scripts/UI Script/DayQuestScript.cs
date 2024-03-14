using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayQuestScript : MonoBehaviour
{
    public int MaxCount;
    public List<GameObject> ExplainPanelList = new List<GameObject>();

    public GameObject proceeding;
    public GameObject accept;
    public GameObject complete;
    public GameObject finish;
    public Text QuestText;
    public GameObject explainPanel;

    public bool Quest;

    void Update()
    {
        //��¥�� �ٲ�� �ٽ� ������ư ����
        if (string.Format(System.DateTime.Now.ToString("dd")) != string.Format(PlayerPrefs.GetString(this.name + "Clearday")))
        {
            PlayerPrefs.SetInt(this.name + "BeforeCount", MaxCount);
            PlayerPrefs.SetString(this.name + "_Quest", " ");
            accept.SetActive(true);
            proceeding.SetActive(false);
            complete.SetActive(false);
            finish.SetActive(false);
            Quest = false;
        }
        if (PlayerPrefs.GetString(this.name + "_Quest") == "Finish")
        {
            accept.SetActive(false);
            proceeding.SetActive(false);
            complete.SetActive(false);
            finish.SetActive(true);
        }
        //����Ʈ�� �������̸� �����ѵ� ������ �߰� �ϱ�
        if (PlayerPrefs.GetString(this.name + "_Quest") == "Proceeding")
        {
            Quest = true;
            accept.SetActive(false);
            proceeding.SetActive(true);
            complete.SetActive(false);
            finish.SetActive(false);
        }
        //Maxcount �޾ƿ���
        MaxCount = PlayerPrefs.GetInt(this.name+"_MaxCount");
        Exercise_Max_Count();
      
        //���� ����Ʈ ����
        PlayerPrefs.SetInt(this.name + "BattlePoint_Reward", PlayerPrefs.GetInt(this.name + "BeforeCount") / 10);
       //��� ����
        PlayerPrefs.SetInt(this.name + "Gold_Reward", PlayerPrefs.GetInt(this.name+"BattlePoint_Reward") * 1000);

        if (Quest && MaxCount> PlayerPrefs.GetInt(this.name + "BeforeCount"))
        {
            accept.SetActive(false);
            proceeding.SetActive(false);
            complete.SetActive(true);
            finish.SetActive(false);
        }                
    }

    void Exercise_Max_Count()
    {
        if (MaxCount < 10)
        {
            MaxCount = 10;
            QuestText.text = ($"{MaxCount}");       
        }
        else
        {
            QuestText.text = ($"{PlayerPrefs.GetInt(this.name + "BeforeCount")}");
        }
    }

    public void AcceptButton()
    {
        //����Ʈ ���� ��ư�� ������ ����Ʈ ������
        Quest = true;
        PlayerPrefs.SetInt(this.name + "BeforeCount", MaxCount);
        PlayerPrefs.SetString(this.name + "_Quest", "Proceeding");
        accept.SetActive(false);
        proceeding.SetActive(true);
        complete.SetActive(false);
        finish.SetActive(false);
        PlayerPrefs.SetString(this.name + "Clearday", System.DateTime.Now.ToString("dd"));
    }

    public void CompleteButton()
    {   
        Quest = false;
        PlayerPrefs.SetString(this.name + "_Quest", "Finish");
        PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + PlayerPrefs.GetInt(this.name + "Gold_Reward"));
        PlayerPrefs.SetInt("BattlePoint", PlayerPrefs.GetInt("BattlePoint") + PlayerPrefs.GetInt(this.name + "BattlePoint_Reward"));
        accept.SetActive(false);
        proceeding.SetActive(false);
        complete.SetActive(false);
        finish.SetActive(true);
        PlayerPrefs.SetString(this.name+"Clearday", System.DateTime.Now.ToString("dd"));
    }

    public void ExplainPanel()
    {
        ExplainPanelList.Add(explainPanel);
        for(int i =0; i < ExplainPanelList.Count; i++)
        {
            ExplainPanelList[i].SetActive(false);
            Debug.Log("false");
        }
        explainPanel.SetActive(true);
        Debug.Log("true");
    }
}
