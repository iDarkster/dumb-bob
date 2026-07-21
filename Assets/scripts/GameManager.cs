using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            //audioSource.clip = menuMusic;
            audioSource.clip = gameplayMusic;
            audioSource.Play();
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
    public void PlayButtonPressed()
    {
        if (audioSource.clip == gameplayMusic)
        {
            return;
        }
        audioSource.Stop();
        audioSource.clip = gameplayMusic;
        audioSource.Play();
        TransitionManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // or directly 1?
    }

}