using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{    //Scene Change
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    // Start is called before the first frame update
    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
    }
    public void img1()
    {
        image1.SetActive(false);
        image2.SetActive(true);
        image3.SetActive(false);
    }
    public void img2()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(true);
    }
    public void img3()
    {
        PlayerPrefs.SetInt("game_start_bgm_on_off", 0);
        LoadingSceneController.LoadScene("Village");
    }

}
