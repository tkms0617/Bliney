using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpeechCards : MonoBehaviour
{
    [SerializeField] KeyCode _key;
    [SerializeField] SpeechCard[] _speechCards;
    [Space(10f)]
    [SerializeField] TextMeshProUGUI _speakerSlot;
    [SerializeField] TextMeshProUGUI _speechSlot;
    [SerializeField] Image _speechBox;
    [SerializeField] UnityEvent _events;

    byte _index = 0;

    private void Start()
    {
        FlipCard();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            FlipCard();
        }
    }

    void FlipCard()
    {
        if(_speechCards.Length > _index)
        {
            _speechBox.gameObject.SetActive(true);
            _speechCards[_index].Print(_speakerSlot, _speechSlot);
        }
        else
        {
            if(_events != null)
            {
                _events.Invoke();
                _events = null;
            }
            _speakerSlot.text = "";
            _speechSlot.text = "";
            _speechBox.gameObject.SetActive(false);
        }
        ++_index;
    }

    public void NewStashOfCards(SpeechCard[] cards, bool autoStart, UnityEvent _Event = null)
    {
        _speechCards = new SpeechCard[cards.Length];
        _speechCards = cards;
        if(_Event != null)
        {
            _events = _Event;
        }
        _index = 0;
        if (autoStart)
        {
            FlipCard();
        }
    }
}
