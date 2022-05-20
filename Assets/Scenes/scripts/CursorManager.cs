using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {

        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape)) 
            Cursor.lockState = CursorLockMode.None;
        
    }
}
