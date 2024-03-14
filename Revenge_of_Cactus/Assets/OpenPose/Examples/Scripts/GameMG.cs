using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMG : MonoBehaviour
{
    //effect

    //map
    public GameObject forest;
    public GameObject desert;
    public GameObject volcano;
    public GameObject boss_forest;

    //Left_Arm
    GameObject L_Hand;
    GameObject L_Elbow;
    GameObject L_Shoulder;
    float L_Arm_Angle = 0;


    //Right_Arm
    GameObject R_Hand;
    GameObject R_Elbow;
    GameObject R_Shoulder;
    float R_Arm_Angle = 0;

    //Left_Foot
    GameObject L_Foot;
    GameObject L_Knee;
    GameObject L_Thigh;
    float L_Leg_Angle = 0;

    //Rignt_Foot
    GameObject R_Foot;
    GameObject R_Knee;
    GameObject R_Thigh;
    float R_Leg_Angle = 0;

    //Push_Up
    float Push_Up_Angle = 0;
    int Push_Up_Count_Number = 0;
    bool Push_Up_Start = false;
    bool Exercise_Pose_Ready = false;
    bool Exercise_Pose_root = false;
    int push_up_count_take; 

    //Squat
    bool Squat_Start = false;
    float Squat_Angle = 0;
    int Squat_Count_Number = 0;
    int Squat_count_take;

    //Plank
    bool Plank_Start = false;
    float Plank_Angle = 0;
    int Plank_count_take;
    float plank_timer;

    //take_exercise_case
    string Battle_or_Exercise_check;
    string Exercise_case;

    //Punch_check
    int Exercise_Kind_count;
    string Exercise_Kind_Success = "not_done";
    bool monster_attack;
    bool user_get_hit_onOff = true;
    bool gameClear = true;

    //about user variable
    public Animator User_ani;
    int user_HP;
    int fill_user_HP;
    int user_damage;
    int user_defense;
    int user_kick_damage;
    int punch_count_N = 0;
    int kick_count_N = 0;
    int Kick_count_N = 0;
    bool punch_count_onoff = false;
    bool kick_count_onoff = false;
    bool user_attack1_ready;
    bool user_attack2_ready;
    bool user_attack3_ready;

    // about monster variable
    private Animator monster_ani;
    int monster_attack_time = 0;
    int monster_HP;
    int fill_monster_HP;
    float timer;
    bool monster_attack_ready;
    int monster_attack2_ready;
    string monster_name;
    bool monster_pattern_onoff_80percent = true;
    bool monster_pattern_onoff_50percent = true;
    bool monster_pattern_onoff_30percent = true;
    bool monster_pattern_onoff_2 = false;
    int monster_damage;
    int monster_defence;
    int monster_second_damage;
    int monster_level;
    int monster_coin;
    float monster_pattern_time;
    bool monster_patter_finish_effect = false;
    int monster_patter_number=0;

    //UI
    public GameObject gameover_UI;
    public Slider monster_HP_bar;
    public Text monster_HP_Text;
    public Slider user_HP_bar;
    public Text user_HP_Text;
    public Camera cam;
    public GameObject HP_UI;
    public Text Push_Up_Count_text;
    public GameObject Push_Up_UI;
    public GameObject battle_pattern_UI;
    public Text battle_pattern_explain;
    float result_timer = 0;

    //effects
    public ParticleSystem MHit;
    public ParticleSystem UHit;

    //Audio
    private AudioSource Sound;
    public AudioClip Hit1;
    public AudioClip Hit2;
    public void Start()
    {
        map_reset();
        get_data_from_scen();
        Exercise_or_Battle_view();
        monster_attack_time = (int)Random.Range(3f, 5f);
        Sound = GetComponent<AudioSource>();

    }
    public void get_data_from_scen()
    {
        Battle_or_Exercise_check = PlayerPrefs.GetString("Battle_OR_Exercise");
        Exercise_case = PlayerPrefs.GetString("Player_Exercise_Kind");
        push_up_count_take = PlayerPrefs.GetInt("Player_Exercise_Count");
        Squat_count_take = PlayerPrefs.GetInt("Player_Exercise_Count");
        Plank_count_take = PlayerPrefs.GetInt("Player_Exercise_Count");
        monster_name = PlayerPrefs.GetString("Monster_Name");
        //user setting
        user_HP = 100 + PlayerPrefs.GetInt("Health") * 5;
        fill_user_HP = 100 + PlayerPrefs.GetInt("Health") * 5;
        user_damage = PlayerPrefs.GetInt("Power");
        user_defense = PlayerPrefs.GetInt("Defense");
        user_kick_damage = PlayerPrefs.GetInt("Kick_Damage");
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        result_timer += Time.deltaTime;
        //streaming joint point
        Connect_Obj();
        //angle_calculate
        Angle_Cal();

        Push_Up();
        Squat();
        Plank();
        //battle_start
        Battle_Check();
        //exercise
        Exercise_Method();
    }
    public void Exercise_or_Battle_view()
    {
        if (Battle_or_Exercise_check == "Exercise")
        {
            Push_Up_Count_text.text = ("준비 자세를 취해주세요.");
            Vector3 monster_position = new Vector3(260f, -54f, 254f);
            cam.transform.position = monster_position;
            cam.orthographic = true;
            cam.orthographicSize = 200;
            cam.fieldOfView = 63.5f;
        }
        if (Battle_or_Exercise_check == "Battle")
        {
            monster_Spawn();
            Vector3 monster_position = new Vector3(285f, -190f, -302f);
            Vector3 monster_rotation = new Vector3(14f, -50f, 0);
            cam.orthographic = false;
            cam.transform.position = monster_position;
            cam.transform.eulerAngles = monster_rotation;
            cam.fieldOfView = 63.5f;
            HP_UI.SetActive(true);
        }

    }
    public void monster_Spawn()
    {
        if(Battle_or_Exercise_check == "Battle")
        {
            switch (monster_name)
            {
                case "Slime":
                    forest.SetActive(true);
                    SlimeSpawn();
                    break;
                case "TurtleShell":
                    forest.SetActive(true);
                    TurtleSpawn();
                    break;
                case "Skeleton":
                    desert.SetActive(true);
                    SkeletonSpawn();
                    break;
                case "Golem":
                    volcano.SetActive(true);
                    GolemSpawn();
                    break;
                case "EvilMage":
                    boss_forest.SetActive(true);
                    MageSpawn();
                    break;
            }
        }
        
    }
    public void map_reset()
    {
        PlayerPrefs.SetInt("Result_Push_Up_Count", 0);
        PlayerPrefs.SetInt("Result_Squat_Count", 0);
        PlayerPrefs.SetInt("Result_Plank_Count", 0);
        forest.SetActive(false);
        desert.SetActive(false);
        volcano.SetActive(false);
        boss_forest.SetActive(false);
        Push_Up_Count_text.text = ("자세를 제대로 잡아주세요");
        monster_pattern_time = 200;
    }
    public void monster_Clear()
    {
        if(gameClear)
        {
            switch (monster_name)
            {
                
                case "Slime":
                    PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + monster_coin);
                    int Slime_Clear_Count = PlayerPrefs.GetInt("Slime_clear") + 1;
                    PlayerPrefs.SetInt("Slime_clear", Slime_Clear_Count);
                    gameClear = false;
                    break;
                case "TurtleShell":
                    PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + monster_coin);
                    int TurtleShell_Clear_Count = PlayerPrefs.GetInt("TurtleShell_clear") + 1;
                    PlayerPrefs.SetInt("TurtleShell_clear", TurtleShell_Clear_Count);
                    gameClear = false;
                    break;
                case "Skeleton":
                    PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + monster_coin);
                    int Skeleton_Clear_Count = PlayerPrefs.GetInt("Skeleton_clear") + 1;
                    PlayerPrefs.SetInt("Skeleton_clear", Skeleton_Clear_Count);
                    gameClear = false;
                    break;
                case "Golem":
                    PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + monster_coin);
                    int Golem_Clear_Count = PlayerPrefs.GetInt("Golem_clear") + 1;
                    PlayerPrefs.SetInt("Golem_clear", Golem_Clear_Count);
                    gameClear = false;
                    break;
                case "EvilMage":
                    PlayerPrefs.SetInt("Coin_Total", PlayerPrefs.GetInt("Coin_Total") + monster_coin);
                    int EvilMage_Clear_Count = PlayerPrefs.GetInt("EvilMage_clear") + 1 ;
                    PlayerPrefs.SetInt("EvilMage_clear", EvilMage_Clear_Count);
                    gameClear = false;
                    break;
            }
            
        }

    }
    public void HP_check()
    {
        if (monster_HP < 0)
        {
            monster_HP = 0;
        }
        if (user_HP < 0)
        {
            user_HP = 0;
        }
    }
    public void Connect_Obj()
    {
        //Left Arm
        L_Hand = GameObject.FindWithTag("L_Hand");
        L_Elbow = GameObject.FindWithTag("L_Elbow");
        L_Shoulder = GameObject.FindWithTag("L_Shoulder");
        //Right Arm
        R_Hand = GameObject.FindWithTag("R_Hand");
        R_Elbow = GameObject.FindWithTag("R_Elbow");
        R_Shoulder = GameObject.FindWithTag("R_Shoulder");
        //Left Foot
        L_Foot = GameObject.FindWithTag("L_Foot");
        L_Knee = GameObject.FindWithTag("L_Knee");
        L_Thigh = GameObject.FindWithTag("L_Thigh");
        //Right Foot
        R_Foot = GameObject.FindWithTag("R_Foot");
        R_Knee = GameObject.FindWithTag("R_Knee");
        R_Thigh = GameObject.FindWithTag("R_Thigh");
    }
    //Battle_method
    public void Battle_Check()
    {
        if (Battle_or_Exercise_check == "Battle")
        {
            
            //monster, user HP_check
            HP_check();
            //monster,user_HP_check
            monster_HP_bar.value = (float)monster_HP / fill_monster_HP;
            monster_HP_Text.text = string.Format("HP : {0} / {1}", monster_HP, fill_monster_HP);
            user_HP_bar.value = (float)user_HP / fill_user_HP;
            user_HP_Text.text = string.Format("HP : {0} / {1}", user_HP, fill_user_HP);

            //user_victory, monster_die
            if (monster_HP <= 0)
            {
                PlayerPrefs.SetString("Result_S_or_F", "성공");
                PlayerPrefs.SetInt("Result_coin", monster_coin);
                PlayerPrefs.SetInt("Result_Time", (int)result_timer);
                monster_Clear();
                Invoke("Game_over_menu", 2f);
                monster_ani.SetBool("hp_0_die", true);
                User_ani.SetBool("user_Victory", true);
                HP_UI.SetActive(false);
                
            }
            //monster_victory, user_die
            if (user_HP <= 0)
            {
                PlayerPrefs.SetString("Result_S_or_F", "실패");
                PlayerPrefs.SetInt("Result_coin", 0);
                PlayerPrefs.SetInt("Result_Time", (int)result_timer);
                Invoke("Game_over_menu", 2f);
                monster_ani.SetBool("monster_win", true);
                User_ani.SetBool("user_die", true);
                HP_UI.SetActive(false);
            }
            if(Exercise_Kind_Success == "fail")
            {
                battle_pattern_UI.SetActive(true);
                battle_pattern_explain.text = string.Format("마법진이 완성되었습니다. 토벌 실패");
                HP_UI.SetActive(false);
                cam.orthographic = false;
                Vector3 monster_position = new Vector3(285f, -190f, -300f);
                Vector3 monster_rotation = new Vector3(14f, -50f, 0);
                cam.fieldOfView = 63.5f;
                cam.transform.position = monster_position;
                cam.transform.eulerAngles = monster_rotation;
                user_HP = 0;
            }
            if(Exercise_Kind_Success == "done")
            {
                HP_UI.SetActive(true);
                cam.orthographic = false;
                Vector3 monster_position = new Vector3(285f, -190f, -300f);
                Vector3 monster_rotation = new Vector3(14f, -50f, 0);
                cam.fieldOfView = 63.5f;
                cam.transform.position = monster_position;
                cam.transform.eulerAngles = monster_rotation;
                monster_ani.SetBool("pattern", false);
                monster_ani.SetBool("get_hit", true);
                User_ani.SetBool("attack_3", true);
                Invoke("pattern_punch_delay", 0.45f);
                Invoke("monster_get_hit_delay", 0.5f);
                monster_HP = monster_HP - (user_kick_damage + user_damage);

                Exercise_Kind_Success = "not_yet";

            }
            if(((100*monster_HP/fill_monster_HP)>=20 && (100 *monster_HP / fill_monster_HP)<=30) && monster_pattern_onoff_30percent)
            {
                push_up_count_take = 5 * monster_level;
                battle_pattern_UI.SetActive(true);
                battle_pattern_explain.text = string.Format("몬스터가 마법진을 완성하기전에. 푸쉬업 {0}회로 반격하세요", push_up_count_take);
                Battle_pattern_0();
                monster_pattern_onoff_30percent = false;
                monster_patter_number = 3;
            }
            if(((100 * monster_HP / fill_monster_HP) >= 50 && (100 * monster_HP / fill_monster_HP) <= 60) && monster_pattern_onoff_50percent)
            {
                Plank_count_take = 10 * monster_level;
                battle_pattern_UI.SetActive(true);
                battle_pattern_explain.text = string.Format("몬스터가 마법진을 완성하기전에. 플랭크 {0}초로 반격하세요", Plank_count_take);
                Battle_pattern_0();
                monster_pattern_onoff_50percent = false;
                monster_patter_number = 2;

            }
            if (((100 * monster_HP / fill_monster_HP) >= 70 && (100 * monster_HP / fill_monster_HP) <= 80) && monster_pattern_onoff_80percent)
            {
                Squat_count_take = 5 * monster_level;
                battle_pattern_UI.SetActive(true);
                battle_pattern_explain.text = string.Format("몬스터가 마법진을 완성하기전에. 스쿼트 {0}회로 반격하세요", Squat_count_take);
                Battle_pattern_0();
                monster_pattern_onoff_80percent = false;
                monster_patter_number = 1;
            }

            if(!monster_pattern_onoff_2)
            {
                //attack
                if (user_attack1_ready)
                {

                    User_ani.SetBool("attack_1", true);
                    monster_ani.SetBool("get_hit", true);
                    Invoke("punch_delay", 0.2f);
                    Invoke("monster_get_hit_delay", 0.5f);
                    if(monster_defence >= user_damage)
                    {
                        monster_HP = monster_HP - 0;
                    }
                    if(monster_defence < user_damage)
                    {
                        monster_HP = monster_HP - (user_damage - monster_defence);
                    }
                    user_attack1_ready = false;
                    MHit.Play();
                    Sound.PlayOneShot(Hit1);

                }
                
                if ((punch_count_onoff && L_Arm_Angle < 10) || (punch_count_onoff && R_Arm_Angle < 10))
                {
                    punch_count_N++;
                    if (punch_count_N == 1)
                    {
                        user_attack1_ready = true;
                    }
                    punch_count_onoff = false;

                }
                if (!punch_count_onoff && L_Arm_Angle > 90 && R_Arm_Angle > 90)
                {
                    User_ani.SetBool("user_defence", true);
                    punch_count_onoff = true;
                }
                //kick_attack_ready
                if (user_attack2_ready)
                {
                    User_ani.SetBool("attack_2", true);
                    monster_ani.SetBool("get_hit", true);
                    Invoke("kick_delay", 0.25f);
                    Invoke("monster_get_hit_delay", 0.5f);
                    if (monster_defence >= user_kick_damage)
                    {
                        monster_HP = monster_HP - 0;
                    }
                    if (monster_defence < user_kick_damage)
                    {
                        monster_HP = monster_HP - (user_kick_damage - monster_defence);
                    }
                    user_attack2_ready = false;
                    MHit.Play();
                    Sound.PlayOneShot(Hit1);
                }
                if ((kick_count_onoff && L_Leg_Angle > 70) || (kick_count_onoff && R_Leg_Angle > 70))
                {
                    kick_count_N++;
                    if (kick_count_N == 1)
                    {
                        user_attack2_ready = true;
                    }
                    kick_count_onoff = false;

                }
                if (!kick_count_onoff && L_Leg_Angle < 10 && R_Leg_Angle < 10)
                {
                    kick_count_onoff = true;
                }

                //monster_attack_ready

                if (timer > monster_attack_time && user_HP >0 && monster_HP > 0 && !User_ani.GetBool("attack_1") && !monster_attack_ready)
                {
                    monster_attack_ready = true;
                    monster_attack2_ready++;
                    timer = 0;
                }
                if (monster_attack_ready && monster_attack2_ready % 3 != 0)
                {
                    monster_attack_ready = false;
                    monster_ani.SetBool("attack_1", true);
                    User_ani.SetBool("get_hit", true);
                    Invoke("user_get_delay", 0.15f);
                    if (user_defense >= monster_damage)
                    {
                        user_HP = user_HP - 0;
                    }
                    if (user_defense < monster_damage)
                    {
                        user_HP = user_HP - (monster_damage - user_defense);
                    }
                    UHit.Play();
                    Sound.PlayOneShot(Hit2);

                }
                if (monster_attack_ready && monster_attack2_ready % 3 == 0)
                {
                    monster_ani.SetBool("attack_2", true);
                    User_ani.SetBool("get_hit", true);
                    Invoke("user_get_delay", 0.15f);
                    if (user_defense >= monster_second_damage)
                    {
                        user_HP = user_HP - 0;
                    }
                    if (user_defense < monster_second_damage)
                    {
                        user_HP = user_HP - (monster_second_damage - user_defense);
                    }
                    monster_attack_ready = false;
                    monster_attack2_ready = 0;
                    UHit.Play();
                    Sound.PlayOneShot(Hit2);
                }
            }
            //punch_attack_ready
            
        }
    }
    public void monster_get_hit_delay()
    {
        monster_ani.SetBool("get_hit", false);
    }
    public void Game_over_menu()
    {
        gameover_UI.SetActive(true);
    }
    public void user_get_delay()
    {
        monster_ani.SetBool("attack_1", false);
        monster_ani.SetBool("attack_2", false);
        User_ani.SetBool("get_hit", false);
    }
    public void pattern_punch_delay()
    {
        User_ani.SetBool("attack_3", false);
    }
    public void punch_delay()
    {
        User_ani.SetBool("attack_1", false);
        punch_count_N = 0;
    }
    public void kick_delay()
    {
        User_ani.SetBool("attack_2", false);
        kick_count_N = 0;
    }
    public void monster_get_delay()
    {
        monster_ani.SetBool("get_hit", false);
    }
    public void Battle_pattern_0()
    {
        monster_pattern_onoff_2 = true;
        HP_UI.SetActive(true);
        Vector3 monster_position = new Vector3(200f, -120f, -500f);
        Vector3 monster_rotation = new Vector3(15f, -50f, 0);
        cam.transform.position = monster_position;
        cam.transform.eulerAngles = monster_rotation;
        cam.fieldOfView = 35f;
        monster_ani.SetBool("pattern", true);
        Invoke("Battle_pattern_1", 2f);
    }
    public void Battle_pattern_1()
    {
        Vector3 monster_position = new Vector3(285f, -190f, -300f);
        Vector3 monster_rotation = new Vector3(14f, -50f, 0);
        cam.fieldOfView = 63.5f;
        cam.transform.position = monster_position;
        cam.transform.eulerAngles = monster_rotation;
        Invoke("Battle_pattern_2", 2f);
    }
    public void Battle_pattern_2()
    {
        Vector3 monster_position = new Vector3(260f, -54f, 254f);
        cam.transform.position = monster_position;
        cam.orthographic = true;
        cam.orthographicSize = 200;
        HP_UI.SetActive(false);
        if(monster_patter_number ==1) Squat_Start = true;
        if(monster_patter_number == 2) Plank_Start = true;
        if (monster_patter_number == 3) Push_Up_Start = true;
    }
    //Exercise_method
    public void Exercise_Method()
    {
        if (Battle_or_Exercise_check == "Exercise")
        {
            HP_UI.SetActive(false);
            switch (Exercise_case)
            {
                case "Push_Up":
                    Push_Up_Start = true;
                    break;
                case "Squat":
                    Squat_Start = true;
                    break;
                case "Plank":
                    Plank_Start = true;
                    break;

            }
            if(Exercise_Kind_Success == "done")
            {
                SceneManager.LoadScene("Gym");
            }
        }
    }
    public int Compare_Count(int before, int after)
    {
        int big = 0;
        if(before >= after)
        {
            big = before;
        }
        if(before < after)
        {
            big = after;
        }
        return big;
    }
    public void Push_Up()
    {
        if(Push_Up_Start)
        {
            //monster_pattern_timer
            if(Battle_or_Exercise_check == "Battle")
            {
                battle_pattern_explain.text = string.Format("마법진 완성까지 {0}초", (int)monster_pattern_time);
                monster_pattern_time -= Time.deltaTime;
                if(monster_pattern_time <= 0)
                {
                    battle_pattern_explain.text = string.Format("마법진이 완성되었습니다. 토벌 실패");
                    Exercise_Kind_Success = "fail";
                    Push_Up_Start = false;
                    Push_Up_UI.SetActive(false);
                    monster_pattern_onoff_2 = false;
                    battle_pattern_UI.SetActive(false);
                }
            }
            //exercise
            Push_Up_UI.SetActive(true);
            //초반 준비자세
            if (R_Shoulder != null && R_Foot != null && R_Hand != null && 20 < Push_Up_Angle && Push_Up_Angle < 30 && !Exercise_Pose_Ready && Push_Up_Count_Number != push_up_count_take)
            {
                Push_Up_Count_text.text = ("준비되었습니다!");
                Exercise_Pose_Ready = true;
            }
            //굽히면 카운트
            if (!Exercise_Pose_root && R_Shoulder != null && R_Foot != null && R_Hand != null && Push_Up_Angle < 10 && 0 < Push_Up_Angle && Exercise_Pose_Ready && Push_Up_Count_Number != push_up_count_take)
            {
                PlayerPrefs.SetInt("Result_Push_Up_Count",PlayerPrefs.GetInt("Result_Push_Up_Count")+1);
                Push_Up_Count_Number++;
                Push_Up_Count_text.text = (Push_Up_Count_Number+"개");
                Exercise_Pose_root = true;
            }
            //자세가 돌아오면 준비
            if (Exercise_Pose_root && R_Shoulder != null && R_Foot != null && R_Hand != null && 20 < Push_Up_Angle && Push_Up_Angle < 30 && Push_Up_Count_Number != push_up_count_take)
            {
                Exercise_Pose_root = false;
            }
            //카운트만큼 다 하면
            if (Push_Up_Count_Number == push_up_count_take)
            {
                if(Battle_or_Exercise_check =="Exercise")
                {
                    PlayerPrefs.SetInt("Push_Up_MaxCount", Compare_Count(PlayerPrefs.GetInt("Push_Up_MaxCount"), push_up_count_take));
                    PlayerPrefs.SetString("Succeed_OR_Fail", "Succeed");
                }
                
                Push_Up_UI.SetActive(false);
                monster_pattern_onoff_2 = false;
                battle_pattern_UI.SetActive(false);
                
                Exercise_Kind_Success = "done";
                //PlayerPrefs.SetString("Player_Exercise_Success", Exercise_Kind_Success);
                Exercise_Pose_Ready = false;
                Exercise_Pose_root = false;
                Push_Up_Count_Number = 0;
                Push_Up_Start = false;
                Push_Up_Count_text.text = ("자세를 제대로 잡아주세요");
            }
        }
    }
    public void Squat()
    {
        if(Squat_Start)
        {
            //monster_pattern_timer
            if (Battle_or_Exercise_check == "Battle")
            {
                battle_pattern_explain.text = string.Format("마법진 완성까지 {0}초", (int)monster_pattern_time);
                monster_pattern_time -= Time.deltaTime;
                if (monster_pattern_time <= 0)
                {
                    battle_pattern_explain.text = string.Format("마법진이 완성되었습니다. 토벌 실패");
                    Exercise_Kind_Success = "fail";
                    Push_Up_Start = false;
                    Push_Up_UI.SetActive(false);
                    monster_pattern_onoff_2 = false;
                    battle_pattern_UI.SetActive(false);
                }
            }
            //exercise
            Push_Up_UI.SetActive(true);
            if (R_Shoulder != null && R_Thigh!= null && R_Knee != null && (Squat_Angle>170 && Squat_Angle < 190) && !Exercise_Pose_Ready && Squat_Count_Number != Squat_count_take)
            {
                Push_Up_Count_text.text = ("준비되었습니다!");
                Exercise_Pose_Ready = true;
            }
            if(!Exercise_Pose_root && R_Shoulder != null && R_Thigh != null && R_Knee != null && (Squat_Angle > 65 && Squat_Angle <80) && Exercise_Pose_Ready && Squat_Count_Number != Squat_count_take)
            {
                PlayerPrefs.SetInt("Result_Squat_Count", PlayerPrefs.GetInt("Result_Squat_Count") + 1);
                Squat_Count_Number++;
                Push_Up_Count_text.text = (Squat_Count_Number + "개 했습니다.");
                Exercise_Pose_root = true;
            }
            if (Exercise_Pose_root && R_Shoulder != null && R_Thigh != null && R_Knee != null && (Squat_Angle > 170 && Squat_Angle < 190) && Squat_Count_Number != Squat_count_take)
            {
                Exercise_Pose_root = false;
            }
            if (Squat_Count_Number == Squat_count_take)
            {
                if (Battle_or_Exercise_check == "Exercise")
                {
                    PlayerPrefs.SetInt("Squat_MaxCount", Compare_Count(PlayerPrefs.GetInt("Squat_MaxCount"), Squat_count_take));
                    PlayerPrefs.SetString("Succeed_OR_Fail", "Succeed");
                }
                
                Push_Up_UI.SetActive(false);
                monster_pattern_onoff_2 = false;
                battle_pattern_UI.SetActive(false);
                Exercise_Kind_Success = "done";

                //PlayerPrefs.SetString("Player_Exercise_Success", Exercise_Kind_Success);
                Exercise_Pose_Ready = false;
                Exercise_Pose_root = false;
                Squat_Count_Number = 0;
                Squat_Start = false;
                Push_Up_Count_text.text = ("자세를 제대로 잡아주세요");
            }
        }
    }
    public void Plank()
    {
        if (Plank_Start)
        {
            //monster_pattern_timer
            if (Battle_or_Exercise_check == "Battle")
            {
                battle_pattern_explain.text = string.Format("마법진 완성까지 {0}초", (int)monster_pattern_time);
                monster_pattern_time -= Time.deltaTime;
                if (monster_pattern_time <= 0)
                {
                    Exercise_Kind_Success = "fail";
                    Push_Up_Start = false;
                    Push_Up_UI.SetActive(false);
                    monster_pattern_onoff_2 = false;
                    battle_pattern_UI.SetActive(false);
                }
            }
            //exercise
            Push_Up_UI.SetActive(true);

            /*            //초반 준비자세
                        if (R_Shoulder != null && R_Foot != null && R_Hand != null && 20 < Plank_Angle && Plank_Angle < 30 && !Exercise_Pose_Ready && plank_timer < Plank_count_take)
                        {
                            Push_Up_Count_text.text = ("준비되었습니다!");
                            Exercise_Pose_Ready = true;
                        }*/

            Exercise_Pose_Ready = true;

            //굽히면 카운트
            if (!Exercise_Pose_root && R_Shoulder != null && R_Foot != null && R_Hand != null && (Plank_Angle < 20 && 10 < Plank_Angle ) && (R_Arm_Angle >80 && R_Arm_Angle <100)&& Exercise_Pose_Ready && plank_timer < Plank_count_take)
            {
                Push_Up_Count_text.text = ((int)plank_timer + " 초");
                plank_timer += Time.deltaTime;
                PlayerPrefs.SetInt("Result_Plank_Count", (int)plank_timer);
            }

            
            //카운트만큼 다 하면
            if (Plank_count_take <= plank_timer)
            {
                if (Battle_or_Exercise_check == "Exercise")
                {
                    PlayerPrefs.SetInt("Plank_MaxCount", Compare_Count(PlayerPrefs.GetInt("Plank_MaxCount"), Plank_count_take));
                    PlayerPrefs.SetString("Succeed_OR_Fail", "Succeed");
                }
                
                Push_Up_UI.SetActive(false);
                monster_pattern_onoff_2 = false;
                battle_pattern_UI.SetActive(false);
                Exercise_Kind_Success = "done";
                //PlayerPrefs.SetString("Player_Exercise_Success", Exercise_Kind_Success);
                Exercise_Pose_Ready = false;
                Exercise_Pose_root = false;
                Push_Up_Count_Number = 0;
                Push_Up_Start = false;
                Plank_Start = false;
                Push_Up_Count_text.text = ("자세를 제대로 잡아주세요");
            }
        }
    }
    public void Angle_Cal()
    {
        L_Arm_Angle = vec_cal(L_Hand, L_Elbow, L_Shoulder, L_Arm_Angle);
        R_Arm_Angle = vec_cal(R_Hand, R_Elbow, R_Shoulder, R_Arm_Angle);
        L_Leg_Angle = vec_cal(L_Foot, L_Knee, L_Thigh, L_Leg_Angle);
        R_Leg_Angle = vec_cal(R_Foot, R_Knee, R_Thigh, R_Leg_Angle);
        Push_Up_Angle = Exercise_vec_cal(R_Hand, R_Foot, R_Shoulder, Push_Up_Angle);
        Squat_Angle = Exercise_vec_cal(R_Shoulder, R_Thigh,R_Knee, Squat_Angle);
        Plank_Angle = Exercise_vec_cal(R_Elbow, R_Foot, R_Shoulder, Plank_Angle);
    }

    public float vec_cal(GameObject A, GameObject B, GameObject C, float D)
    {
        float angle = D;
        if (A != null && B != null && C != null)
        {
            angle = Vector3.Angle((A.transform.position - B.transform.position), (B.transform.position - C.transform.position));
        }
        return angle;
    }
    public float Exercise_vec_cal(GameObject A, GameObject B, GameObject C, float D)
    {
        float angle = D;
        if (A != null && B != null && C != null)
        {
            angle = Vector3.Angle((A.transform.position - B.transform.position), (C.transform.position - B.transform.position));
        }
        return angle;
    }
    public void MageSpawn()
    {
        monster_coin = 700 + PlayerPrefs.GetInt("EvilMage_clear") * 50;
        monster_level = 5;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find("Monster_Package").transform.GetChild(i).gameObject.SetActive(false);
        }
        monster_HP = 500 + PlayerPrefs.GetInt("EvilMage_clear") * 20;
        fill_monster_HP = 500 + PlayerPrefs.GetInt("EvilMage_clear") * 20;
        monster_damage = 30 + PlayerPrefs.GetInt("EvilMage_clear");
        monster_defence = 25 + PlayerPrefs.GetInt("EvilMage_clear");
        monster_second_damage = 40 + PlayerPrefs.GetInt("EvilMage_clear");
        GameObject.Find("Monster_Package").transform.GetChild(0).gameObject.SetActive(true);
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
    }
    public void GolemSpawn()
    {
        monster_coin = 600 + PlayerPrefs.GetInt("Golem_clear") * 50;
        monster_level = 4;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find("Monster_Package").transform.GetChild(i).gameObject.SetActive(false);
        }
        monster_HP = 400 + PlayerPrefs.GetInt("Golem_clear") * 20;
        fill_monster_HP = 400 + PlayerPrefs.GetInt("Golem_clear") * 20;
        monster_damage = 20 + PlayerPrefs.GetInt("Golem_clear");
        monster_defence = 20 + PlayerPrefs.GetInt("Golem_clear");
        monster_second_damage = 22 + PlayerPrefs.GetInt("Golem_clear");
        GameObject.Find("Monster_Package").transform.GetChild(1).gameObject.SetActive(true);
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
    }
    public void SkeletonSpawn()
    {
        monster_coin = 500 + PlayerPrefs.GetInt("Skeleton_clear") * 50;
        monster_level = 3;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find("Monster_Package").transform.GetChild(i).gameObject.SetActive(false);
        }
        monster_HP = 300 + PlayerPrefs.GetInt("Skeleton_clear") * 20;
        fill_monster_HP = 300 + PlayerPrefs.GetInt("Skeleton_clear") *20;
        monster_damage = 12 + PlayerPrefs.GetInt("Skeleton_clear");
        monster_defence = 8 + PlayerPrefs.GetInt("Skeleton_clear");
        monster_second_damage = 14 + PlayerPrefs.GetInt("Skeleton_clear");
        GameObject.Find("Monster_Package").transform.GetChild(2).gameObject.SetActive(true);
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
    }
    public void TurtleSpawn()
    {
        monster_coin = 400 + PlayerPrefs.GetInt("TurtleShell_clear") * 50;
        monster_level = 2;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find("Monster_Package").transform.GetChild(i).gameObject.SetActive(false);
        }
        monster_HP = 200 + PlayerPrefs.GetInt("TurtleShell_clear") * 20;
        fill_monster_HP = 200 + PlayerPrefs.GetInt("TurtleShell_clear") * 20;
        monster_damage = 4 + PlayerPrefs.GetInt("TurtleShell_clear");
        monster_defence = 4 + PlayerPrefs.GetInt("TurtleShell_clear");
        monster_second_damage = 5 + PlayerPrefs.GetInt("TurtleShell_clear");
        GameObject.Find("Monster_Package").transform.GetChild(3).gameObject.SetActive(true);
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
    }
    public void SlimeSpawn()
    {
        monster_coin = 300 + PlayerPrefs.GetInt("Slime_clear") * 50;
        monster_level = 1;
        for (int i = 0; i < 5; i++)
        {
            GameObject.Find("Monster_Package").transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject.Find("Monster_Package").transform.GetChild(4).gameObject.SetActive(true);
        monster_ani = GameObject.Find("Monster_Package").GetComponentInChildren<Animator>();
        monster_HP = 100 + PlayerPrefs.GetInt("Slime_clear") * 20;
        fill_monster_HP = 100 + PlayerPrefs.GetInt("Slime_clear") * 20;
        monster_damage = 5 + PlayerPrefs.GetInt("Slime_clear");
        monster_defence = 1 + PlayerPrefs.GetInt("Slime_clear");
        monster_second_damage = 6 + PlayerPrefs.GetInt("Slime_clear");
    }
}

