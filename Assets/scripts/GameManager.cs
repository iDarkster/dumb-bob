using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void ResetLevel()
    {
        TransitionManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Debug.Log("ENTEr NExT LEVEL HERE");
        TransitionManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}