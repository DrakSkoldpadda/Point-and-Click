﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interacteble, IInteract
{
    public GateToOpen gate;
    private Animator anim;

    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
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
        gate.locked = false;
        anim.SetTrigger("On");
    }
}
