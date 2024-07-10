using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseImage;
    public Button resumeButton;
    public Button quitButton;
    public string menuSceneName = "Menu"; // ????????

    private bool isPaused = false;

    void Start()
    {
        SetPauseMenuActive(false);

        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Camera.main.GetComponent<firstPerson>().enabled = false;

        SetPauseMenuActive(true);

        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Camera.main.GetComponent<firstPerson>().enabled = true;

        SetPauseMenuActive(false);

        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void QuitGame()
    {
        Time.timeScale = 1f; // ????????????
        AudioListener.pause = false;
        Camera.main.GetComponent<firstPerson>().enabled = true;
        SceneManager.LoadScene(menuSceneName);
    }

    private void SetPauseMenuActive(bool isActive)
    {
        pauseImage.SetActive(isActive);
        resumeButton.gameObject.SetActive(isActive);
        quitButton.gameObject.SetActive(isActive);
    }
}