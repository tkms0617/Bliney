using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [Tooltip("What object this item can be used againt")]
    public GameObject _usage;

    [SerializeField] UnityEvent _event;

    public GameObject GetUsage()
    {
        if(_event != null)
        {
            _event.Invoke();
        }
        return _usage;
    }
}
