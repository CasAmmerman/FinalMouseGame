using UnityEngine;

public class GroundScanner : MonoBehaviour
{
    public float ScanDist = 1.3f;
    PlatformMove mostRecentPlatform;
    bool currentlyRiding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        RaycastHit info;
        Debug.DrawRay(transform.position, Vector3.down*ScanDist, Color.cyan);
        if(Physics.Raycast(transform.position, Vector3.down, out info, ScanDist))
        {
          
            //check info to see if it's hitting a platform
            //if we hit a platform, then call the public AddRider here
            //if we have hit a platform in the past, but did not, then call remove rider
        }
    }
}
