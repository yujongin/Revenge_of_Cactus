using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    Vector3 Target = new Vector3(110f, 45f, 48f);
    public Quaternion TargetRot;

    // Start is called before the first frame update
    void Start()
    {
        TargetRot = Quaternion.Euler(32f,-90f,0f);
    }
    void Update()
    {
        CameraMove();
    }
    // Update is called once per frame
    public void CameraMove()
    {
        transform.position = Vector3.Lerp(transform.position,Target, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation,TargetRot, Time.deltaTime * 2f);
    }
}
