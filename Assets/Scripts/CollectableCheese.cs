using UnityEngine;

public class CollectableCheese : MonoBehaviour
{
    public int value = 1; // How much this cube is worth

    private void OnTriggerEnter(Collider other)
     {

        if (other.CompareTag("Player"))
        {

            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(value);
            }

            Destroy(gameObject);
        }
    }

}
