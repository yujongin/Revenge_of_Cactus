using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_sc : MonoBehaviour
{
    public Text push_up_count;
    public Text squat_count;
    public Text plank_count;
    public Text play_time;
    public Text coin;
    public Text succed_fail;

    // Start is called before the first frame update
    void Start()
    {
        push_up_count.text = string.Format("«™Ω¨æ˜ {0}»∏",PlayerPrefs.GetInt("Result_Push_Up_Count"));
        squat_count.text = string.Format("Ω∫ƒı∆Æ {0}»∏", PlayerPrefs.GetInt("Result_Squat_Count"));
        plank_count.text = string.Format("«√∑©≈© {0}√ ", PlayerPrefs.GetInt("Result_Plank_Count"));
        PlayerPrefs.SetInt("Result_Push_Up_Count", 0);
        PlayerPrefs.SetInt("Result_Squat_Count", 0);
        PlayerPrefs.SetInt("Result_Plank_Count", 0);
        play_time.text = string.Format("«√∑π¿Ã≈∏¿” : {0}√ ", PlayerPrefs.GetInt("Result_Time"));
        coin.text = string.Format("»πµÊ ƒ⁄¿Œ : {0}", PlayerPrefs.GetInt("Result_coin"));
        succed_fail.text = string.Format("{0}", PlayerPrefs.GetString("Result_S_or_F"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
