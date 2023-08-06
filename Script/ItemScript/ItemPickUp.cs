using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : InteractiveObject {

    public Item item;

    
    public override void Interact()
    { 
        
        base.Interact();
        
        pickUp();
        
    }


    public void pickUp()
    {   
        Inventory.instance.Add(item);
        Destroy(gameObject);

    }



}
