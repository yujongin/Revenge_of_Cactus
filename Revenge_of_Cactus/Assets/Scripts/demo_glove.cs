using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_glove : MonoBehaviour
{
    GameObject glove;
    string glove_name;
    // Start is called before the first frame update
    void Start()
    {
        glove_name = PlayerPrefs.GetString("thisGlove");
        glove = GameObject.Find("Gloves").gameObject;
        glove.transform.Find((string)glove_name).gameObject.SetActive(true);
        
        //GameObject.Find("C01").transform.Find((string)PlayerPrefs.GetString("thisGlove")).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
