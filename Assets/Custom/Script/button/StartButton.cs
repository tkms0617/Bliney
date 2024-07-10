using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public string sceneName; // ????????

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene); // ?????????????ChangeScene???????
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // ????????

        Time.timeScale = 1f; // ????????????
        AudioListener.pause = false;
        Camera.main.GetComponent<firstPerson>().enabled = true;
    }
}
