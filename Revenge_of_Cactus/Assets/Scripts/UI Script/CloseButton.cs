using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject BuildingUI;

    public void closeUI()
    {
       BuildingPos.CameraMoveCheck = false;
       BuildingUI.SetActive(false);
       
    }
}
