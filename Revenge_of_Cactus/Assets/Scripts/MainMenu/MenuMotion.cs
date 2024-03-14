using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMotion : MonoBehaviour
{
    bool shake_bool = true;
    public Camera mainCamera;
    Vector3 cameraPos;

    Vector3 Target = new Vector3(110f, 45f, 48f);
    public Quaternion TargetRot;

    [SerializeField] [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField] [Range(0.1f, 1f)] float duration = 0.3f;


    private Animator animator;
    public GameObject Menu;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        TargetRot = Quaternion.Euler(32f, -90f, 0f);

       // Invoke("attack", 2f);
    }
    void Update()
    {
      
       if(this.transform.position.z <= 20)
        {
            attack();
            Invoke("CameraMove", 0.5f);
        }
    }

    public void attack()
    {
        animator.SetBool("attack", true);
        Menu.SetActive(true);
        Invoke("Shake", 0.1f);
        /*Shake();*/

    }

    public void CameraMove()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, Target,Time.deltaTime);
        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, TargetRot, Time.deltaTime);
    }
    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }
    void StartShake()
    {
        if(shake_bool == true)
        {
            float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
            float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
            Vector3 cameraPos = mainCamera.transform.position;
            cameraPos.x += cameraPosX;
            cameraPos.y += cameraPosY;
            mainCamera.transform.position = cameraPos;
        }
        else
        {

        }
        
    }

    void StopShake()
    {
        shake_bool = false;
        mainCamera.transform.position = cameraPos;
    }

}
