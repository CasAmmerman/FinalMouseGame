using UnityEngine;

public class PushScript : MonoBehaviour
{
    public float pushForce = 20f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pushable"))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null && !rb.isKinematic)
            {
                // Direction from player to cube
                Vector3 pushDir = (hit.transform.position - transform.position).normalized;
                // Add a little upward and random motion
                Vector3 randomBoost = new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f));
                Vector3 finalForce = (pushDir + randomBoost).normalized * pushForce;

                rb.AddForce(finalForce, ForceMode.Impulse);
            }
        }
    }
}
