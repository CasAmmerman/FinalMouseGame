using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour
{
    public string sceneName; // Set this in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            SceneManager.LoadScene(1);
        }
    }
}
