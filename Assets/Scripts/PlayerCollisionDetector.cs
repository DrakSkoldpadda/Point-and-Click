using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private Player player;

    private void Start()
    {

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.canPoint = true;
        player.targetPos = player.transform.position;
    }
}
