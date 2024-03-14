using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_detection : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "hand")
        {
            Debug.Log("공격완료");
        }
    }
    private void Update()
    {
        Invoke("move_wall", 2f);
    }
    public void move_wall()
    {
        transform.position = new Vector3(-1.5f , 2 , 0);
    }
}
