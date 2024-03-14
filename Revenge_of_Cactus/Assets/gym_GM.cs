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
            explain.text = "��� ��� ���½��ϴ�.";
        }
        if(PlayerPrefs.GetString("Succeed_OR_Fail") == "Fail")
        {
            if (A == "Push_Up")
            {
                A = "Ǫ����";
                exercise_explain_txt1.text = "Ǫ������ ������� �Ӹ����� �߱��� ����ó�� ������� �����ּ���.";
                exercise_explain_txt2.text = "������ ���� �ڼ��� ������ֽð� ����źе��� ������ ��� ���ּ���.";
                img1.GetComponent<RawImage>().texture = Img[0];
                img2.GetComponent<RawImage>().texture = Img[1];
                explain.text = string.Format("�����Ͻ� ��� {0} {1}ȸ�Դϴ�.", A, B);
            }
            if (A == "Squat")
            {
                A = "����Ʈ";
                exercise_explain_txt1.text = "����Ʈ�� �����ڼ��� �Ӹ����� �߱��� ����ó�� ������� �����ּ���.";
                exercise_explain_txt2.text = "������ �����̰� �ٴڰ� ������ �ǵ��� �ڼ��� ������ּ���.";
                img1.GetComponent<RawImage>().texture = Img[2];
                img2.GetComponent<RawImage>().texture = Img[3];
                explain.text = string.Format("�����Ͻ� ��� {0} {1}ȸ�Դϴ�.", A, B);
            }
            if (A == "Plank")
            {
                A = "�÷�ũ";
                exercise_explain_txt1.text = "�÷�ũ�� �غ��ڼ��� ���������� �ʽ��ϴ�. �ٷ� �����Ͻø� �˴ϴ�.";
                exercise_explain_txt2.text = "���� �Ⱥκ��� ����ó�� ������ֽø� ī��Ʈ�� ���۵˴ϴ�.";
                img1.GetComponent<RawImage>().texture = Img[4];
                img2.GetComponent<RawImage>().texture = Img[5];
                explain.text = string.Format("�����Ͻ� ��� {0} {1}���Դϴ�.", A, B);
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
