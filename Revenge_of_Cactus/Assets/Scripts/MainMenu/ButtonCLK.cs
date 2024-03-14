using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCLK : MonoBehaviour
{
    public void OnClickSceneChange()
    {
        LoadingSceneController.LoadScene("StoryScene");
        /*SceneManager.LoadScene("StoryScene");*/
    }
    public void OnClickExit()
    {
        Application.Quit();
        
    }

    public void OnClickSetting()
    {
        Debug.Log("BUTTON CLICK SETTING");
    }
}
