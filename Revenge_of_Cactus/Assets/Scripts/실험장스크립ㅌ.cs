using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class 실험장스크립ㅌ : MonoBehaviour
{
    private Animator animator;


    int monster_HP;
    bool doing;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        monster_HP = 10;
        doing = false;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && doing==false)
        {
            doing = true;
            animator.SetBool("attack",true);
            Invoke("attack_reset", 1f);
        }
        if (Input.GetKeyDown(KeyCode.S) && doing == false)
        {
            doing = true;
            animator.SetBool("attack_2", true);
            Invoke("attack_reset", 1f);
        }
        if (Input.GetKeyDown(KeyCode.D) && doing == false)
        {
            doing = true;
            monster_HP--;
            animator.SetBool("Get_Hit", true);
            animator.SetInteger("Monster_HP", monster_HP);
            Invoke("get_hit_reset", 1f);
        }
    }
    public void attack_reset()
    {
        animator.SetBool("attack", false);
        animator.SetBool("attack_2",false);
        doing = false;
    }
    public void get_hit_reset()
    {
        animator.SetBool("Get_Hit", false);
        doing = false;
        Debug.Log(monster_HP);
    }
}
