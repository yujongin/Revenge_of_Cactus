using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGlove : MonoBehaviour
{
    public GloveStatus gloveStatus;

    public GameObject Gloves;

    public GameObject thisGlove;
    

    public List<GameObject> GloveList = new List<GameObject>();
    public Text priceText;
    public Text MoneyText;
    public int Money;
    public int price;
    public GameObject PurchaseBtn;
    public GameObject EquipBtn;
    public GameObject InstalledBtn;

    private bool EquipCheck = false;
    public List<GameObject> UIList = new List<GameObject>();
    public GameObject Weapon;

    public Text GloveStatusText;


    public PlayerGlove playerGlove;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString(this.name) == this.name)
        {
            PurchaseBtn.SetActive(false);
            EquipBtn.SetActive(true);
            InstalledBtn.SetActive(false);
        }
        if (this.name == PlayerPrefs.GetString("thisGlove"))
        {
            thisGlove.SetActive(true);
            PurchaseBtn.SetActive(false);
            EquipBtn.SetActive(false);
            InstalledBtn.SetActive(true);
            EquipCheck = true;
        }

       
        for (int i = 1; i < 11; i++)
        {
            UIList.Add(Weapon.transform.Find("Glove" + i).gameObject);
        }

        for (int i = 1; i < 11; i++)
        {
            GloveList.Add(Gloves.transform.Find("Glove"+i).gameObject);
        }
        
    }

    private void Update()
    {
        GloveStatusText.text = ($"공격력:{gloveStatus.plusPower}   방어력:{gloveStatus.plusDefense} \n체력:{gloveStatus.plusHealth}      발차기:{gloveStatus.plusKickDamage}");
    }
    //구매버튼
    public void Purchase()
    {
        
        MoneyText = MoneyText.GetComponent<Text>();
        priceText = priceText.GetComponent<Text>();
        
        Money = int.Parse(MoneyText.text);
        price = int.Parse(priceText.text);
        if (price <= Money)
        {
            PlayerPrefs.SetString(this.name, this.name);
            int change = Money - price;
            PlayerPrefs.SetInt("Coin_Total", change);
            PurchaseBtn.SetActive(false);
            EquipBtn.SetActive(true);
            InstalledBtn.SetActive(false);
            SoundManager.instance.PlayClickSound();
        }
    }

    //장착버튼
    public void Equipment()
    {
        for (int i =0; i <= 9; i++)
        {
            GloveList[i].SetActive(false);
        }
        EquipCheck = true;
        thisGlove.SetActive(true);
        PlayerPrefs.SetString("thisGlove", thisGlove.name);
        string a = PlayerPrefs.GetString("thisGlove");
        PurchaseBtn.SetActive(false);
        EquipBtn.SetActive(false);
        InstalledBtn.SetActive(true);
        PlayerPrefs.SetInt("Power",PlayerPrefs.GetInt("Power")+gloveStatus.plusPower);
        PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + gloveStatus.plusDefense);
        PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + gloveStatus.plusHealth);
        PlayerPrefs.SetInt("Kick_Damage", PlayerPrefs.GetInt("Kick_Damage") + gloveStatus.plusKickDamage);
        SoundManager.instance.PlayClickSound();
        //다른 글러브 장착중 다시 장착버튼으로 바꾸기
        for (int i = 0; i <= 9; i++)
        {
            playerGlove = UIList[i].GetComponent<PlayerGlove>();
            if (playerGlove.EquipCheck&&this.name!=playerGlove.name)
            {
                playerGlove.PurchaseBtn.SetActive(false);
                playerGlove.EquipBtn.SetActive(true);
                playerGlove.InstalledBtn.SetActive(false);
                PlayerPrefs.SetInt("Power", PlayerPrefs.GetInt("Power") - playerGlove.gloveStatus.plusPower);
                PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") - playerGlove.gloveStatus.plusDefense);
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - playerGlove.gloveStatus.plusHealth);
                PlayerPrefs.SetInt("Kick_Damage", PlayerPrefs.GetInt("Kick_Damage") - playerGlove.gloveStatus.plusKickDamage);
            }
        }
    }

}
