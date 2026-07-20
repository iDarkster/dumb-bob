using UnityEngine;

public class WinFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BobBrain bob = other.GetComponent<BobBrain>();

        if (bob != null)
        {
            GameManager.Instance.NextLevel();
        }
    }
}