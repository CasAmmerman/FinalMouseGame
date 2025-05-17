using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
   

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return; // Ensure the player has the "Player" tag

        var inv = other.GetComponent<PlayerInventory>();
        if (inv != null && inv.HasCheese)
        {
            ScoreManager.Instance.AddPoint();
            inv.RemoveCheese();
        }
    SceneManager.LoadScene(2);
    }
}
