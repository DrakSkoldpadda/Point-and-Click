using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinDoor : Interacteble, IInteract
{
    public GameObject youWinMenu;

    protected override void Start()
    {
        base.Start();

        youWinMenu.SetActive(false);
    }

    protected void OnMouseDown()
    {
        if (player.transform.position.x - transform.position.x > -3f && player.transform.position.x - transform.position.x < 3f)
        {
            Interact();
        }
    }

    public void Interact()
    {
        YouWin();
    }

    void YouWin()
    {
        Time.timeScale = 0f;
        youWinMenu.SetActive(true);
    }
}
