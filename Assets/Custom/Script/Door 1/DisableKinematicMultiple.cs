using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableKinematicMultiple : MonoBehaviour
{
    List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                _rigidbodies.Add(rigidbody);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce((PlayerManager.GetPlayerTransform().forward + PlayerManager.GetPlayerTransform().position - rigidbody.transform.position) * 10, ForceMode.Impulse);
            rigidbody.transform.SetParent(null);
        }
        if(TryGetComponent<BoxCollider>(out BoxCollider collider))
        {
            Destroy(collider);
        }
        Destroy(gameObject);
    }
}
