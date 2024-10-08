using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SpaceTitle : MonoBehaviour
{
    public Image fadeImage; // ??????UI Image
    public float fadeDuration = 1f; // ?????????????
    public string sceneToLoad; // ????????
    public float autoTransitionDelay = 10f; // ???????????

    private float timeSinceLastKeyPress = 0f; // ??????????????

    private void Update()
    {
        // ?????????????????????????????
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("AutoTransition");
            StartCoroutine(FadeAndLoadScene());
        }
        else
        {
            // ?????????????????????????
            timeSinceLastKeyPress += Time.deltaTime;

            // 10?????????????????
            if (timeSinceLastKeyPress >= autoTransitionDelay)
            {
                StartCoroutine(FadeAndLoadScene());
                timeSinceLastKeyPress = 0f; // ?????????
            }
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        // ???????
        yield return StartCoroutine(Fade(1f));

        // ????????
        SceneManager.LoadScene(sceneToLoad);

        // ??????????????
        yield return new WaitForSeconds(0.1f); // ??????????????

        // ??????????
        yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float alpha = fadeImage.color.a;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(alpha, targetAlpha, timeElapsed / fadeDuration);
            Color color = fadeImage.color;
            color.a = newAlpha;
            fadeImage.color = color;
            yield return null;
        }

        // ????????????
        Color finalColor = fadeImage.color;
        finalColor.a = targetAlpha;
        fadeImage.color = finalColor;
    }
}
