using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody _rigidBody;
    [SerializeField] CapsuleCollider _capsule;
    [SerializeField] AudioSource _footsteps;
    public int _moveState = 0;
    public float _walkSpeed;
    public float _runSpeed;
    public float _tiptoeSpeed;
    public GameObject _maincamera;
    [SerializeField] float _height;


    Vector3 _accum = Vector3.zero;
    const float _oneThirds = 0.8f;
    bool _run = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ExampleMove();
    }
void ExampleMove()
    {
        _moveState = 0;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            _moveState = 2;
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            _moveState = 1;
        }
        else if(Input.GetKey(KeyCode.LeftShift)){
            _moveState= 3;
        }

        if (_run)
        {
            _moveState = 3;
        }

        float speed = 0;

        switch (_moveState)
        {
            case 1: speed = _tiptoeSpeed; if (!_footsteps.isPlaying) _footsteps.Play(); _footsteps.pitch = 0.8f; _footsteps.volume =  _oneThirds * 0.5f; break;
            case 2: speed = _walkSpeed; if (!_footsteps.isPlaying) _footsteps.Play(); _footsteps.pitch = 1; _footsteps.volume = _oneThirds; break;
            case 3: speed = _runSpeed; if (!_footsteps.isPlaying) _footsteps.Play(); _footsteps.pitch = 1.2f; _footsteps.volume = _oneThirds * 1.2f; break;
            default: _footsteps.Stop(); break;
        }

        MoveByKey(KeyCode.W, _maincamera.transform.forward, ref _accum);
        MoveByKey(KeyCode.A, -_maincamera.transform.right, ref _accum);
        MoveByKey(KeyCode.S, -_maincamera.transform.forward, ref _accum);
        MoveByKey(KeyCode.D, _maincamera.transform.right, ref _accum);

        if(_moveState != 0)
        {
            Debug.Log("Yep");
            Physics.SphereCast(_maincamera.transform.position, _capsule.radius + 0.01f, Vector3.down, out RaycastHit hit, _maincamera.transform.position.y - transform.position.y + _capsule.height * 0.5f * transform.lossyScale.y);
            Physics.Raycast(hit.point + Vector3.up, Vector3.down, out hit, 1.1f);
            _accum -= Vector3.Dot(hit.normal, _accum) * hit.normal;
            _accum *= speed;
            _rigidBody.velocity = Vector3.Scale(_accum, Vector3.forward + Vector3.right) + Vector3.up * ((_accum.y > 0.1f) ? _accum.y: _rigidBody.velocity.y);
        }
        _accum = Vector3.zero;
    }

    void MoveByKey(KeyCode key, Vector3 direction, ref Vector3 accum)
    {
        if (Input.GetKey(key))
        {
            accum += direction;
        }
    }

    public void Run()
    {
        _run = true;
    }
}
        

