using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item thisItem;

    public GameObject popUpTextPrefab;

    private GameObject player;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        inventory = player.GetComponent<Inventory>();

        if (thisItem != null)
        {
            ChangeImage();
        }

        //TODO: This doesn't work
        //Both colliders are there
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
    }

    public void ChangeImage()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = thisItem.itemSprite;

        Collider2D collider = gameObject.AddComponent<PolygonCollider2D>();
    }

    GameObject textPopUp;

    private void OnMouseEnter()
    {
        textPopUp = Instantiate(popUpTextPrefab, new Vector2(transform.position.x, transform.position.y + 2f), Quaternion.identity);
        textPopUp.GetComponent<TextMeshPro>().text = thisItem.description;
    }

    private void OnMouseExit()
    {
        Destroy(textPopUp);
    }

    private void OnMouseDown()
    {
        if (player.transform.position.x - transform.position.x > -1f && player.transform.position.x - transform.position.x < 1f)
        {
            PickUp();
        }
    }

    void PickUp()
    {
        if (inventory.equippedItem == null)
        {
            inventory.PickUpItem(thisItem);

            Destroy(textPopUp);
            OnMouseExit();
            Destroy(gameObject);
        }
    }
}
