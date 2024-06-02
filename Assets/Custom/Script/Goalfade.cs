using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goalfade : MonoBehaviour
{
    [SerializeField] GameObject Fade;
    Fade script;
    [SerializeField] GameObject Text;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Fade == null) Fade = GameObject.Find("Fadepanel");
        script = Fade.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        script.isFadeout = true;
        Text.SetActive(true);

    }
}
