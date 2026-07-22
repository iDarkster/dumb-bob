using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float holdDuration = 0.2f;

    private bool isTransitioning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Ensure screen starts transparent
            SetAlpha(0f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int buildIndex)
    {
        if (isTransitioning)
            return;

        StartCoroutine(Transition(buildIndex));
    }

    IEnumerator Transition(int buildIndex)
    {
        isTransitioning = true;

        // Fade Out
        yield return StartCoroutine(Fade(0f, 1f));

        // Hold on black
        yield return new WaitForSeconds(holdDuration);

        // Load new scene
        SceneManager.LoadScene(buildIndex);

        // Wait one frame so the new scene is ready
        yield return null;

        // Fade In
        yield return StartCoroutine(Fade(1f, 0f));

        isTransitioning = false;
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            SetAlpha(alpha);

            yield return null;
        }

        SetAlpha(endAlpha);
    }

    void SetAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}