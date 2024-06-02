using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gaping : MonoBehaviour
{
    public bool _open;
    public GameObject _upperJaw;
    public GameObject _lowerJaw;
    public float _speed;
    public float _angleUp;
    public float _angleLow;

    public GameObject _target;
    RaycastHit _hit;

    float _timer;
    Vector3 _initialAngleUp;
    Vector3 _initialAngleLow;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _open = false;
        _initialAngleUp = _upperJaw.transform.localEulerAngles;
        _initialAngleLow = _lowerJaw.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();
        Gape();
    }

    void SetTimer()
    {
        if( _open)
        {
            if(_timer < 1)
            {
                _timer += _speed * Time.deltaTime;
                if(_timer >= 1)
                {
                    _timer = 1;
                }
            }
        }
        else
        {
            if(_timer > 0)
            {
                _timer -= _speed * Time.deltaTime;
                if(_timer < 0)
                {
                    _timer = 0;
                }
            }
        }
    }

    void Gape()
    {
        float timer = 0.5f - 0.5f * Mathf.Cos(_timer * Mathf.PI);
        float upperAngle = _angleUp * timer;
        float lowerAngle = _angleLow * timer;
        _upperJaw.transform.localEulerAngles = _initialAngleUp + new Vector3(0, 0, upperAngle);
        _lowerJaw.transform.localEulerAngles = _initialAngleLow + new Vector3(0, 0, lowerAngle);
    }

    void CastRay()
    {
        Physics.Raycast(transform.position, _target.transform.position - transform.position, out _hit);
        if (_hit.collider.gameObject == _target)
        {
            _open = true;
        }
        else
        {
            _open = false;
        }
    }
}
