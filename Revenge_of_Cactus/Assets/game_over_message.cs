using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over_message : MonoBehaviour
{
    public Button again_bt;
    public Button home_bt;
    public Text txt;
    float time = 0;
    

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.GetComponent<Image>().color = new Color(255f, 255f, 255f, time/5);
        txt.GetComponent<Text>().color = new Color(1, 1, 1, time / 5);


    }


}
