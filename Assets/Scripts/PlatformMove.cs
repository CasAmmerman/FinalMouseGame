using UnityEngine;
using System.Collections; 

public class PlatformMove : MonoBehaviour
{
    public Transform pointA;  
    public Transform pointB;  
    public float speed = 2f;  
    public float waitTime = 1f;  

    private Vector3 target;   
    private bool isWaiting = false;


    public Vector3 DeltaMovement { get; private set; }
    private Vector3 lastPosition;


    void Update()
    {
        DeltaMovement = transform.position - lastPosition;
        lastPosition = transform.position;
        if (!isWaiting)
        {
            MovePlatform();
        }
    }

    void FixedUpdate()
    {
        DeltaMovement = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }
    void Start()
    {
        target = pointB.position;
    }

    void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    IEnumerator WaitAndSwitch()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        target = (target == pointA.position) ? pointB.position : pointA.position;
        isWaiting = false;
    }

   
   
}
