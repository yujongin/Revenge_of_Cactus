using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gym_GM : MonoBehaviour
{
    public Text explain;
    public Text exercise_explain_txt1;
    public Text exercise_explain_txt2;
    public Texture[] Img = new Texture[6];
    public GameObject img1;
    public GameObject img2;

    public GameObject go_exercise_button;
    public GameObject explain_canvas_1;
    public GameObject explain_canvas_2;

    string A;
    int B;

    public GameObject sun;

    // Start is called before the first frame update
    void Start()
    {
/*        sun.SetActive(false);
        Invoke("sun_on", 0.05f);*/
        A = PlayerPrefs.GetString("Player_Exercise_Kind");
        B = PlayerPrefs.GetInt("Player_Exercise_Count");
        if(PlayerPrefs.GetString("Succeed_OR_Fail") == "Succeed")
        {
            explain_canvas_1.SetActive(false);
            explain_canvas_2.SetActive(false);
            go_exercise_button.SetActive(false);
            explain.text = "모든 운동을 끝냈습니다.";
        }
        if(PlayerPrefs.GetString("Succeed_OR_Fail") == "Fail")
        {
            if (A == "Push_Up")
            {
                A = "푸쉬업";
                exercise_explain_txt1.text = "푸쉬업은 엎드려서 머리부터 발까지 사진처럼 옆모습을 보여주세요.";
                exercise_explain_txt2.text = "사진과 같은 자세를 만들어주시고 힘드신분들은 무릎을 대고 해주세요.";
                img1.GetComponent<RawImage>().texture = Img[0];
                img2.GetComponent<RawImage>().texture = Img[1];
                explain.text = string.Format("선택하신 운동은 {0} {1}회입니다.", A, B);
            }
            if (A == "Squat")
            {
                A = "스쿼트";
                exercise_explain_txt1.text = "스쿼트은 차렷자세로 머리부터 발까지 사진처럼 옆모습을 보여주세요.";
                exercise_explain_txt2.text = "무릎과 엉덩이가 바닥과 평행이 되도록 자세를 만들어주세요.";
                img1.GetComponent<RawImage>().texture = Img[2];
                img2.GetComponent<RawImage>().texture = Img[3];
                explain.text = string.Format("선택하신 운동은 {0} {1}회입니다.", A, B);
            }
            if (A == "Plank")
            {
                A = "플랭크";
                exercise_explain_txt1.text = "플랭크은 준비자세가 정해져있지 않습니다. 바로 시작하시면 됩니다.";
                exercise_explain_txt2.text = "이후 팔부분을 사진처럼 만들어주시면 카운트가 시작됩니다.";
                img1.GetComponent<RawImage>().texture = Img[4];
                img2.GetComponent<RawImage>().texture = Img[5];
                explain.text = string.Format("선택하신 운동은 {0} {1}초입니다.", A, B);
            }


        }
    }
/*    public void sun_on()
    {
        sun.SetActive(true);
    }*/
    public void SceneChangetoGym()
    {
        SceneManager.LoadScene("Demo");
    }
    public void SceneChangetoVillage()
    {
       SceneManager.LoadScene("Village");
    }
}
