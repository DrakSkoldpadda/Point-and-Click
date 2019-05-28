using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Item equippedItem;

    public Image image;

    public GameObject itemObject;

    public TextMeshProUGUI itemNameText;

    // Start is called before the first frame update
    void Start()
    {
        if (equippedItem != null)
        {
            image.enabled = enabled;
            PickUpItem(equippedItem);
        }
        else
        {
            image.enabled = !enabled;
        }
    }

    public void UpdateNameText()
    {
        if (equippedItem != null)
        {
            itemNameText.text = equippedItem.itemName;
        }
        else
        {
            itemNameText.text = "";
        }
    }

    public void PickUpItem(Item item)
    {
        equippedItem = item;
        image.enabled = enabled;
        image.sprite = item.itemSprite;

        UpdateNameText();
    }

    public void DropItem()
    {
        GameObject item = Instantiate(itemObject, transform.position, Quaternion.identity);
        item.GetComponent<ItemObject>().thisItem = equippedItem;
        item.GetComponent<ItemObject>().ChangeImage();
        equippedItem = null;
        image.sprite = null;
        image.enabled = !enabled;

        UpdateNameText();
    }
}
