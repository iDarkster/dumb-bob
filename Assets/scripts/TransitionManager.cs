using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(Transition(buildIndex));
    }

    IEnumerator Transition(int buildIndex)
    {
        // Fade Out
        Debug.Log("SWITCHING");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(buildIndex);

        // Fade In
    }
}