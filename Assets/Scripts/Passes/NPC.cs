using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Pass, IDirection
{
    public Item itemToGiveBack;

    public string itemUnlocked;

    protected GameObject player;

    protected float size;

    protected override void Start()
    {
        base.Start();

        player = GameObject.FindWithTag("Player");

        size = transform.localScale.x;

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
    }

    protected virtual void Update()
    {
        Direction();
    }

    public override void Interact()
    {
        base.Interact();

        infoText.text = itemUnlocked;
        TextPopUp();

        player.GetComponent<Inventory>().PickUpItem(itemToGiveBack);
    }

    public void Direction()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(size, 1);
        }
        else
        {
            transform.localScale = new Vector2(-size, 1);
        }
    }
}
