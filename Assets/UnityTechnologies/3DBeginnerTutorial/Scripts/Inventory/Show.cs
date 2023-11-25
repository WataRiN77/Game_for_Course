using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    public Text txt;
    public Inventory Bag;
    private string showui = "Inventory:\n ";

    private void Start()
    {
        txt.text = "Inventory:\n ";
    }

    private void Update()
    {
        showui = "Inventory:\n ";
        foreach(Item i in Bag.itemList)
        {
            showui += (i.itemName + " *" + i.itemHeld.ToString() + "\n ");
        }
        txt.text = showui;
    }

}
