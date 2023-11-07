using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum InteractableType { Enemy, Item }

public class EnemyInteract : MonoBehaviour
{
    public AttributesManager myActor { get; private set; }

    //public InteractableType interactionType;

    void Awake()
    {
        //if (interactionType == InteractableType.Enemy)
        //{ myActor = GetComponent<AttributesManager>(); }
        myActor = GetComponent<AttributesManager>();
    }

    public void InteractWithItem()
    {
        // Pickup Item
        Destroy(gameObject);
    }
}