using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpeechCardsSetter : MonoBehaviour
{
    [SerializeField] bool _autoStart;
    [SerializeField] SpeechCard[] _cards;
    [SerializeField] UnityEvent _event;
    float _timer = -1;
    bool set = false;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (set && _timer < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<SpeechCards>().NewStashOfCards(_cards, _autoStart);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_autoStart)
        {
            other.transform.GetComponent<SpeechCards>().NewStashOfCards(new SpeechCard[0], _autoStart);
        }
    }

    public void SetSpeechCardAfterTime(float timer)
    {
        set = true;
        _timer = timer;
        PlayerManager.GetSpeechCards().NewStashOfCards(_cards, _autoStart, _event);
    }
}