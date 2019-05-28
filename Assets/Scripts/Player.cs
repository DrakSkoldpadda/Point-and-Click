using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDirection
{
    public float MoveSpeed => speed;
    private float speed = 5f;

    [HideInInspector]
    public bool canPoint = true;
    [HideInInspector]
    public Vector3 targetPos;

    private Animator anim;
    private SpriteRenderer sRend;
    private Rigidbody2D rBody;

    public Collider2D rightCollider;
    public Collider2D leftCollider;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PointDirection();

        if (rBody.velocity.x > 0)
        {
            anim.SetBool("Walking_Right", true);
        }
        else if (rBody.velocity.x < 0)
        {
            anim.SetBool("Walking_Left", true);
        }
        else
        {
            anim.SetBool("Walking_Left", false);
            anim.SetBool("Walking_Right", false);
        }
    }

    void PointDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && canPoint)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector2.up);

            if (hit.collider != null && hit.collider.tag != "Player" && hit.distance <= 3f)
            {
                targetPos = new Vector3(mousePos.x, hit.point.y);

                canPoint = false;
            }
        }

        if (!canPoint)
        {
            Direction();
        }
    }

    public void Direction()
    {
        if (transform.position.x < targetPos.x - 0.01f)
        {
            if (targetPos.x - transform.position.x < speed * Time.deltaTime + 0.07f)
            {
                Vector3 pos = transform.position;
                pos.x = targetPos.x;
                transform.position = pos;
            }
            Move(Vector2.right);
        }
        else if (transform.position.x > targetPos.x + 0.01f)
        {
            if (targetPos.x - transform.position.x > speed * Time.deltaTime - 0.07f)
            {
                Vector3 pos = transform.position;
                pos.x = targetPos.x;
                transform.position = pos;
            }
            Move(Vector2.left);
        }
        else
        {
            rBody.velocity = Vector2.zero;

            canPoint = true;
        }
    }

    public void Move(Vector2 dir)
    {
        Vector2 movement = new Vector2(dir.x * speed, rBody.velocity.y);

        rBody.velocity = movement;
    }
}