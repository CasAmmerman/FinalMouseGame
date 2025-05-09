using UnityEngine;

public class CollectCheese : MonoBehaviour
{
    public GameObject Cheese;
    public Vector3 carrPosition = new Vector3(0, 1, 0.5f);
    private bool isHoldingCheese = false;
    private Rigidbody cheeseRb;

    void Update()
    {
        RaycastHit info;
        Physics.SphereCast(transform.position, 2f, transform.forward, out info);

        if(info.transform != null && info.transform.gameObject.tag == "Cheese")
        {
            Cheese = info.transform.gameObject;
        }

        if (Cheese != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Debug.Log("Pick Up Cheese");
            PickUpCheese();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && isHoldingCheese)
        {
            Debug.Log("Drop Cheese");
            DropCheese();
        }
    }
    private void PickUpCheese()
    {
        cheeseRb = Cheese.GetComponent<Rigidbody>();
        if (cheeseRb != null)
        {
            cheeseRb.isKinematic = true;
        }
        Cheese.transform.SetParent(transform);
        Cheese.transform.localPosition = carrPosition;
        isHoldingCheese = true;
    }

    private void DropCheese()
    {
        if (cheeseRb != null)
        {
            cheeseRb.isKinematic = false;
        }
        Cheese.transform.SetParent(null);
        Cheese = null;
        isHoldingCheese = false;
    }
}
