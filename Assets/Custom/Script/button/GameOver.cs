using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float _speed = 1;
    public float _slideamount;

    public GameObject _enemy;
    public GameObject _camera;

    public string sceneName;

    NavMeshAgent _navMeshAgent;
    firstPerson _firstPerson;
    Move _move;
    Gaping gaping;
    Vector3 _to;
    float _timer = 1;
    float _angle;
    float _slide;
    bool _over;

    private void Start()
    {
        TryGetComponent<Move>(out _move);
        _camera.TryGetComponent<firstPerson>(out _firstPerson);
    }

    private void Update()
    {
        if(_over == true)
        {
            _camera.transform.position -= _to * _slide;
            _to = _enemy.transform.position - _camera.transform.position;
            _camera.transform.LookAt(Vector3.RotateTowards(_camera.transform.forward, _to, _speed * Mathf.PI * Time.deltaTime * 2, 10) + _camera.transform.position, Vector3.up);
            _timer -= Time.deltaTime * _speed;
            float sine = Mathf.Sin(_timer * Mathf.PI);
            _slide = -_slideamount * sine * sine;
            _camera.transform.position += _to * _slide;
        }
        if(_timer <= 0)
        {
            _timer = 0;
            _speed = 0;
            Over();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemy = collision.gameObject;
            _over = true;

            _angle = Vector3.Angle(transform.forward, _enemy.transform.position - transform.position);

            _enemy.TryGetComponent<Gaping>(out gaping);
            _enemy.TryGetComponent<NavMeshAgent>(out _navMeshAgent);
            gaping._open = true;
            Destroy(_move);
            _navMeshAgent.speed = 0;
            Destroy(_firstPerson);
        }
    }

    void Over()
    {
        SceneManager.LoadScene(sceneName);
    }
}
