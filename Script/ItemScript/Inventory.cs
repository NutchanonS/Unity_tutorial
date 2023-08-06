using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 10; //เก็บได้ 10 ช่อง
    public List<Item> items = new List<Item>(); //สร้าง list items
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback; //บอกว่าไอเทมมีการเปลี่ยนแปลง

    void Start()
    {
        
    }

    public void Add(Item item)
    { 
        if (item.showInventory)
        {
            if (items.Count >= space)
                return;
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();

            }
        }
         
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    void Update()
    {
        
    }
}
