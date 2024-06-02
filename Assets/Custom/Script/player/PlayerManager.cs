using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static Transform _transform;
    static SpeechCards _speechCards;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _speechCards = GetComponent<SpeechCards>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Transform GetPlayerTransform()
    {
        return _transform;
    }

    public static SpeechCards GetSpeechCards()
    {
        return _speechCards;
    }
}
