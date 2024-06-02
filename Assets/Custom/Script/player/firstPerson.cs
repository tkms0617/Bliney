using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPerson : MonoBehaviour
{
    public float _sensitivity;
    float _yRotation;
    float _xRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _yRotation += Input.GetAxis("Mouse X");
        _xRotation -= Input.GetAxis("Mouse Y");
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0);
    }
}
