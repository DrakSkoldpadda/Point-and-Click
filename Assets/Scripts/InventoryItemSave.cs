using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSave : MonoBehaviour
{
    public Item savedItem;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameObject.FindWithTag("Player").GetComponent<Inventory>().equippedItem = savedItem;
    }

}
