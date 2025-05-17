using UnityEngine;

public class GroundScanner : MonoBehaviour
{
    public float ScanDist = 1.3f;

    PlatformMove mostRecentPlatform;
    bool currentlyRiding;
    

    void FixedUpdate()
    {
        RaycastHit info;
        PlatformMove platform = null;

        Debug.DrawRay(transform.position, Vector3.down*ScanDist, Color.cyan);
        
        if(Physics.Raycast(transform.position, Vector3.down, out info, ScanDist))
        {
            
            //check info to see if it's hitting a platform
           platform = info.collider.GetComponent<PlatformMove>();
           
           if (platform != null)
           {
               //if we hit a platform, then call the public AddRider here
               if (platform != mostRecentPlatform)
               {
                   
                   platform.AddRider(transform);
                   mostRecentPlatform = platform;
                   currentlyRiding = true;
               }
           }
           else
           {
                //if we hit a platform, then call the public AddRider here
                if (currentlyRiding && mostRecentPlatform != null)
                {
                    mostRecentPlatform.RemoveRider(transform);
                    mostRecentPlatform = null;
                    currentlyRiding = false;
                }
           }
       }
        else 
        {
            if (currentlyRiding && mostRecentPlatform != null)
            {
                mostRecentPlatform.RemoveRider(transform);
                mostRecentPlatform = null;
                currentlyRiding = false;
            }
        }
    }
}
