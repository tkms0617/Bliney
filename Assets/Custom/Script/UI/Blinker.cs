using UnityEngine;
using TMPro;

public class Blinker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;

    [Header("????????")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    private float duration = 1.0f;

    [Header("???")]
    [SerializeField]
    private Color32 startColor = new Color32(255, 255, 255, 255);

    [Header("???")]
    [SerializeField]
    private Color32 endColor = new Color32(255, 255, 255, 10); // ?????????10???

    void Awake()
    {
        if (tmp == null)
        {
            tmp = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (tmp != null)
        {
            tmp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
        }
    }
}
