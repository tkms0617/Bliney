
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RequireItem : MonoBehaviour
{
    [Tooltip("The component that becomes enabled/disabled when requirement is met")]
    public Behaviour _behaviour;
    [SerializeField] Behaviour[] _behaviours;
    [SerializeField] UnityEvent _event;
    [Tooltip("Initial/current enability of the behaviour")]
    public bool _enabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _behaviour.enabled = _enabled;
        foreach(Behaviour behaviour in _behaviours)
        {
            behaviour.enabled = _enabled;
        }
        if (_enabled)
        {
            _event.Invoke();
        }
    }
}
