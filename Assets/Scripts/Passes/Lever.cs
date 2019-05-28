using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interacteble, IInteract
{
    public GateToOpen gate;
    public Animator anim;

    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
    }

    protected void OnMouseDown()
    {
        if (GameObject.FindWithTag("Player").transform.position.x - transform.position.x > -1f && GameObject.FindWithTag("Player").transform.position.x - transform.position.x < 1f)
        {
            Interact();
        }
    }

    public void Interact()
    {
        gate.locked = false;
        anim.SetTrigger("On");
    }
}
