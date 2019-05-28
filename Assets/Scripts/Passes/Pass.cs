using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : Interacteble, IInteract
{
    public string wrongItemText;
    public Item itemToInteract;

    protected Inventory playerInventory;

    protected override void Start()
    {
        base.Start();

        playerInventory = player.GetComponent<Inventory>();
    }

    protected virtual void OnMouseDown()
    {
        if (player.transform.position.x - transform.position.x > -1f && player.transform.position.x - transform.position.x < 1f)
        {
            TryUnlock(playerInventory.equippedItem);
        }
    }

    protected virtual void TryUnlock(Item itemTryUnlock)
    {
        if (itemTryUnlock == itemToInteract)
        {
            Interact();
        }
        else
        {
            WrongItem();
        }
    }

    public virtual void Interact()
    {
        playerInventory.equippedItem = null;
        playerInventory.UpdateNameText();
    }

    protected virtual void WrongItem()
    {
        infoText.text = wrongItemText;
        TextPopUp();
    }

    protected virtual IEnumerator TextPopUp()
    {
        infoText.enabled = enabled;
        yield return new WaitForSeconds(1.5f);
        infoText.enabled = !enabled;
    }
}
