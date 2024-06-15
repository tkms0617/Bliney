using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TMP_Text countText;
    private static int count; // static???????

    void Start()
    {
        // ??????????????????0???????
        if (countText != null)
        {
            count = 0;
            UpdateCountText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        {
            // ??????????????? "Player" ???????????????
            if (other.CompareTag("Player"))
                count++; // ????????
            UpdateCountText();
        }
    }
    void UpdateCountText()
    {
        // ????????????
        countText.text = "count: " + count.ToString();
    }
}
