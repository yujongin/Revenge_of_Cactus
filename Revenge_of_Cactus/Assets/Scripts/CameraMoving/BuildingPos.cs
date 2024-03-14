using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPos : MonoBehaviour
{
    public CameraPos camerapos;
    public static Vector3 TargetPos;
    public static Quaternion TargetRot;
    public static bool CameraMoveCheck = false;

    public TypeWriterEffect typeWriter;
    public GameObject CharacterMap;
    public GameObject BuildingUI;
    public GameObject Button;
    public GameObject text;
    void Start()
    {
        typeWriter = text.GetComponent<TypeWriterEffect>();
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!CameraMoveCheck)
        {
            TargetPos = new Vector3(camerapos.Posx, camerapos.Posy, camerapos.Posz);
            TargetRot = Quaternion.Euler(camerapos.Rotx, camerapos.Roty, camerapos.Rotz);
            BuildingUI.SetActive(true);
            CameraMoveCheck = true;
            Button.SetActive(true);
            CharacterMap.SetActive(false);
            typeWriter.text_exit = false;
            typeWriter.Get_Typing(typeWriter.dialog_cnt, typeWriter.fulltext);
        }
        
    }
}
