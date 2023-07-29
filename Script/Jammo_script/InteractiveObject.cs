using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{

    public float radius = 3f;
    public Transform player;
    public Transform interactItem;
    bool hasInteract = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, interactItem.position);
        if (distance <= radius && !hasInteract)
        {
            hasInteract = true;
            Interact();
        }
    }
    public virtual void Interact()
    {
        Debug.Log("Item Active");
    }

}
