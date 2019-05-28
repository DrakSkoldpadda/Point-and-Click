using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : NPC
{
    private Animator anim;

    protected override void Start()
    {
        base.Start();

        infoText.enabled = !enabled;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player.transform.position.x - transform.position.x > -4f && player.transform.position.x - transform.position.x < 4f)
        {
            anim.SetBool("IsVisable", true);
            infoText.enabled = enabled;
        }
        else
        {
            anim.SetBool("IsVisable", false);
            infoText.enabled = !enabled;
        }
    }
}
