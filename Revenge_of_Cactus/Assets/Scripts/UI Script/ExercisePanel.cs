using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExercisePanel : MonoBehaviour
{
    public int count = 1;
    public GameObject Parent;
    public GameObject ECback;
    public GameObject Up;
    public GameObject Down;

    public Text ExerciseCount;
    public GameObject ExerciseKind;
    public ExercisePanel exercisePanel;

    public List<GameObject> ExerciseList = new List<GameObject>();

    public int exerciseCount;

    public Image ExerciseImage;

    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {      
       for(int i = 0; i < Parent.transform.childCount; i++)
        {
            ExerciseList.Add(Parent.transform.GetChild(i).gameObject);
            for (int j = 0; j < Parent.transform.childCount; j++)
            {
                exercisePanel = ExerciseList[i].GetComponent<ExercisePanel>();
                exercisePanel.ECback.SetActive(false);
                exercisePanel.Up.SetActive(false);
                exercisePanel.Down.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        exerciseCount = int.Parse(ExerciseCount.text);
    }
    public void ChoiceExercise()
    {
        ExerciseImage.sprite = sprite;
        PlayerPrefs.SetInt("Player_Exercise_Count", count);
        PlayerPrefs.SetString("Player_Exercise_Kind", ExerciseKind.name);
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            exercisePanel = ExerciseList[i].GetComponent<ExercisePanel>();
            exercisePanel.ECback.SetActive(false);
            exercisePanel.Up.SetActive(false);
            exercisePanel.Down.SetActive(false);
            if (this.name == ExerciseList[i].name)
            {
                exercisePanel.ECback.SetActive(true);
                exercisePanel.Up.SetActive(true);
                exercisePanel.Down.SetActive(true);
            }
        }



    }


    public void AddCount()
    {
       
            count++;
            ExerciseCount.text = count.ToString();
            PlayerPrefs.SetString("Player_Exercise_Kind", ExerciseKind.name);
            PlayerPrefs.SetInt("Player_Exercise_Count", count);

    }
    public void MinusCount()
    {
        count--;       
        if (exerciseCount <= 1)
        {
            count = 1;           
        }
        ExerciseCount.text = count.ToString();
        PlayerPrefs.SetString("Player_Exercise_Kind", ExerciseKind.name);
        PlayerPrefs.SetInt("Player_Exercise_Count", count);

    }

    public void StartBtn()
    {
        //SceneManager.LoadScene(ÈÆ·ÃÀå ¾À);
        PlayerPrefs.GetInt("Player_Exercise_Count");
        PlayerPrefs.SetString("Battle_OR_Exercise","Exercise");
        PlayerPrefs.SetString("Succeed_OR_Fail", "Fail");
        string a = PlayerPrefs.GetString("Battle_OR_Exercise");
        int b = PlayerPrefs.GetInt("Player_Exercise_Count");
        string c = PlayerPrefs.GetString("Player_Exercise_Kind");
        LoadingSceneController.LoadScene("Gym");
/*        SceneManager.LoadScene("Gym");*/

        
    }

}
