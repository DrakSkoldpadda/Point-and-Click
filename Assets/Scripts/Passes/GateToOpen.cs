using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToOpen : Interacteble, IInteract
{
    [HideInInspector]
    public bool locked = true;
    public string sceneToLoad;

    protected void OnMouseDown()
    {
        if (!locked)
        {
            Interact();
        }
        else
        {
            infoText.text = "Can't open";
            TextPopUp();
        }
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    protected virtual IEnumerator TextPopUp()
    {
        infoText.enabled = enabled;
        yield return new WaitForSeconds(1.5f);
        infoText.enabled = !enabled;
    }
}
