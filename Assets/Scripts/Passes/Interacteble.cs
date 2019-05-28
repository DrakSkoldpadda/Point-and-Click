using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interacteble : MonoBehaviour
{
    public string descriptionText;
    protected TextMeshPro infoText;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        infoText = GetComponentInChildren<TextMeshPro>();
        infoText.enabled = !enabled;
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
