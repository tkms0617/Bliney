using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class SpeechCard
{
    [SerializeField] string _speaker;
    [SerializeField] string _speech;

    public void Print(TextMeshProUGUI Speaker, TextMeshProUGUI Speech)
    {
        Speaker.text = _speaker;
        Speech.text = _speech;
    }
}
