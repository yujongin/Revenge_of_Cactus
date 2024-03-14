using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class demo_button : MonoBehaviour
{

    public void go_home()
    {
        SceneManager.LoadScene("Village");
    }
}
