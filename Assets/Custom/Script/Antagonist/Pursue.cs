using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : MonoBehaviour
{
    public NavMeshAgent _pursuer;
    public GameObject _pursuit;
    public Vector3 _roamTarget;

    public float _pursuitDistanceRun;
    public float _pursuitDistanceWalk;
    public float _pursuitDistanceTipToe;
    public float _basicPursuitDistance;

    public bool _chase;

    Move _move;
    float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _move = _pursuit.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        if (_chase)
        {
            _pursuer.destination = _pursuit.transform.position;
            _timer = 5;
        }
        else
        {
            if(Vector3.Distance(_pursuer.destination, transform.position) < _basicPursuitDistance)
            {
                _timer -= Time.deltaTime;
            }
            if (_timer < 0)
            {
                _timer = 0;
            }
            if (_timer <= 0)
            {
                _pursuer.destination = _roamTarget;
            }
        }
    }

    void CheckDistance()
    {
        switch (_move._moveState)
        {
            case 0:
                if(Vector3.Distance(_pursuit.transform.position, transform.position) <= _basicPursuitDistance)
                {
                    _chase = true;
                }
                else
                {
                    _chase = false;
                }
                break;
            case 1:
                if(Vector3.Distance(_pursuit.transform.position, transform.position) <= _pursuitDistanceTipToe)
                {
                    _chase = true;
                }
                else
                {
                    _chase = false;
                }
                break;
            case 2:
                if(Vector3.Distance(_pursuit.transform.position, transform.position) <= _pursuitDistanceWalk)
                {
                    _chase = true;
                }
                else
                {
                    _chase = false;
                }
                break;
            case 3:
                if (Vector3.Distance(_pursuit.transform.position, transform.position) <= _pursuitDistanceRun)
                {
                    _chase = true;
                }
                else
                {
                    _chase = false;
                }
                break;
        }
    }
}
