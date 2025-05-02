using UnityEngine;

public class CollectCheese : MonoBehaviour
{
    public GameObject Cheese;
    public Vector3 carrPosition = new Vector3(0, 1, 0.5f);
    private bool isHoldingCheese = false;

    void Update()
    {
        RaycastHit info;
        Physics.SphereCast(transform.position, 2f, transform.forward, out info);

        if(info.transform.gameObject.tag == "Collectable")
        {
            Cheese = info.transform.gameObject;
        }

        if (Cheese != null && Input.GetKeyDown(KeyCode.E))
        {
            PickUpCheese();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isHoldingCheese)
        {
            DropCheese();
        }
    }
    private void PickUpCheese()
    {
        Cheese.transform.SetParent(transform);
        Cheese.transform.localPosition = carrPosition;
        isHoldingCheese = true;
    }

    private void DropCheese()
    {
        Cheese.transform.SetParent(null);
        Cheese = null;
        isHoldingCheese = false;
    }
}
