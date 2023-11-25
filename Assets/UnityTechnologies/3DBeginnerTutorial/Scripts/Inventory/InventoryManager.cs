using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory Bag;
    public TextUIforInventory txt;

    //private string inv = "Inventory:\n";
    //private string RefreshText;

    void Awake()
    {
        if(instance != null) Destroy(this);
        instance = this;
    }

    public static void CreateNewItem(Item item)
    {
        
    }

    public static void RefreshInventory(Item item)
    {
        /*foreach(Item i in Bag.itemList)
        {
            if(i.itemName == Bag.item.itemName) i.itemHeld += 1;
        }*/
    }

    public void Update()
    {
        /*RefreshText = "";
        foreach(Item i in Bag.itemList)
        {
            RefreshText += (i.itemName + "  " + i.itemHeld.ToString() + "\n ");
        }
        txt.text = inv + RefreshText;*/
    }

}
