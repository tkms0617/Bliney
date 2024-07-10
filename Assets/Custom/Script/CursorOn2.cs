using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOn2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = false;
    }
}