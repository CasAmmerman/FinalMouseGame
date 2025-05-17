using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure the player has the "Player" tag
        {
            SceneManager.LoadScene(2);
        }
    
    }
}
