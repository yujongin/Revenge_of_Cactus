using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play_Explain_MG : MonoBehaviour
{
    public Button prepare_btn;
    public Button normal_punch_btn;
    public Button kick_btn;
    public Button pattern;
    public Button depence;

    public GameObject prepare_img;
    public GameObject normal_img;
    public GameObject kick_img;
    public GameObject pattern_img;
    public GameObject depence_img;

    public void prepare_btn_click()
    {
        prepare_img.SetActive(true);
        normal_img.SetActive(false);
        kick_img.SetActive(false);
        pattern_img.SetActive(false);
        depence_img.SetActive(false);
    }
    public void normal_punch_btn_click()
    {
        prepare_img.SetActive(false);
        normal_img.SetActive(true);
        kick_img.SetActive(false);
        pattern_img.SetActive(false);
        depence_img.SetActive(false);
    }
    public void kick_btn_click()
    {
        prepare_img.SetActive(false);
        normal_img.SetActive(false);
        kick_img.SetActive(true);
        pattern_img.SetActive(false);
        depence_img.SetActive(false);
    }
    public void pattern_btn_click()
    {
        prepare_img.SetActive(false);
        normal_img.SetActive(false);
        kick_img.SetActive(false);
        pattern_img.SetActive(true);
        depence_img.SetActive(false);
    }
    public void depence_btn_click()
    {
        prepare_img.SetActive(false);
        normal_img.SetActive(false);
        kick_img.SetActive(false);
        pattern_img.SetActive(false);
        depence_img.SetActive(true);
    }
    public void Start_btn_click()
    {
        SceneManager.LoadScene("Demo");
    }
    public void Back_btn_click()
    {
        SceneManager.LoadScene("Village");
    }
}
