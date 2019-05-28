using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interacteble : MonoBehaviour
{
    public string descriptionText;
    protected TextMeshPro infoText;

    protected GameObject player;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");

        infoText = GetComponentInChildren<TextMeshPro>();
        infoText.enabled = !enabled;

        if (GetComponent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }

    protected virtual void OnMouseOver()
    {
        infoText.text = descriptionText;
        infoText.enabled = enabled;
    }

    protected virtual void OnMouseExit()
    {
        infoText.enabled = !enabled;
    }
}
