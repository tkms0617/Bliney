using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Blinker : MonoBehaviour
{
    //????????????????????GetComponent???TextMeshProUGUI????????????
    [SerializeField]
    TextMeshProUGUI tmp;
    [Header("1??????(???)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;
    //??????
    [Header("????????")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);
    //??(????)????
    [Header("????????")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);
    //?????????????????GetComponent???????????Awake?????????
    void Awake()
    {
        if (tmp == null)
            tmp = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        tmp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }
}