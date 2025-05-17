using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool HasCheese { get; private set;}

    public void PickUpCheese()
    {
        HasCheese = true;
    }
   
    public void RemoveCheese() => HasCheese = false;
}
