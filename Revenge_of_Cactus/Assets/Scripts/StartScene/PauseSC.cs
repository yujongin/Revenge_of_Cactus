using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSC : MonoBehaviour
{
    bool IsPause;
    public GameObject PAUSE;
    public GameObject Menu;
    public GameObject Quit;
    public GameObject Village;


    public GameObject Help;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        PAUSE.SetActive(false);
        Menu.SetActive(false);
        Help.SetActive(false);
        Quit.SetActive(false);
        Village.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                PAUSE.SetActive(true);
                Menu.SetActive(true);
                return;
            }
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                PAUSE.SetActive(false);
                Quit.SetActive(false);
                Help.SetActive(false);
                return;
            }
        }
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        IsPause = false;
        PAUSE.SetActive(false);
    }
    public void HelpButton()
    {
        Help.SetActive(true);
        Debug.Log("Help");
    }
    public void YesButton()
    {
        Application.Quit();
        Debug.Log("Yes");
    }
    public void VillageYes()
    {
        LoadingSceneController.LoadScene("Village");
        Time.timeScale = 1;

    }
}

