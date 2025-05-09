using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public List<Transform> riders = new List<Transform>();


    void Update()
    {

    }

    void FixedUpdate()
    {
        //debug your delta move here and make sure it's correct
        if (!isWaiting)
        {
            MovePlatform();
        }

        DeltaMovement = transform.position - lastPosition;
        Debug.Log("DeltaMovement: " + DeltaMovement);
       
        foreach (Transform t in riders)
        {   
            Debug.DrawRay(t.position, DeltaMovement, Color.green);
            t.position += DeltaMovement; 
        }


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

    void OnCollisionEnter(Collision collision)
    {
        if (!riders.Contains(collision.transform))
        {
            riders.Add(collision.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        riders.Remove(collision.transform);
    }

    IEnumerator WaitAndSwitch()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        target = (target == pointA.position) ? pointB.position : pointA.position;
        isWaiting = false;
    }

    public void AddRider(Transform t)
    {
        riders.Add(t);
    }

    public void RemoveRider(Transform t)
    {
        riders.Remove(t);
    }

   
   
}
