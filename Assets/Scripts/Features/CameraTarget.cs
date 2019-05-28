using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour, IMove, IDirection
{
    public float MoveSpeed => speed;
    private float speed = 25f;

    private Vector3 desiredPosition;
    private Rigidbody2D rBody;

    public GameObject rightButton;
    public GameObject leftButton;

    public float leftPosCantPress;
    public float rightPosCantPress;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        desiredPosition = transform.position;
    }

    void Update()
    {
        Direction();
    }

    public void Direction()
    {
        if (transform.position.x < desiredPosition.x)
        {
            if (desiredPosition.x - transform.position.x < speed * Time.deltaTime + 0.07f)
            {
                Vector3 pos = transform.position;
                pos.x = desiredPosition.x;
                transform.position = pos;
            }
            Move(Vector2.right);
        }
        else if (transform.position.x > desiredPosition.x)
        {
            if (desiredPosition.x - transform.position.x > speed * Time.deltaTime - 0.07f)
            {
                Vector3 pos = transform.position;
                pos.x = desiredPosition.x;
                transform.position = pos;
            }
            Move(Vector2.left);
        }
        else
        {
            rBody.velocity = Vector2.zero;
        }
    }

    public void MoveRight(bool right)
    {
        if (right)
        {
            desiredPosition = new Vector2(desiredPosition.x + 31, transform.position.y);
        }
        else
        {
            desiredPosition = new Vector2(desiredPosition.x - 31, transform.position.y);
        }

        if (desiredPosition.x <= leftPosCantPress)
        {
            desiredPosition = new Vector3(leftPosCantPress, transform.position.y);
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }
        if (desiredPosition.x >= rightPosCantPress)
        {
            desiredPosition = new Vector3(rightPosCantPress, transform.position.y);
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }

    public void Move(Vector2 dir)
    {
        Vector2 movement = new Vector2(dir.x * speed, rBody.velocity.y);

        rBody.velocity = movement;
    }
}