using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movementX;
    float movementY;
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float jumpPower = 2f;
    bool jumping = false;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityX != 0)
        {
            spriteRenderer.flipX = rb.linearVelocityX < 0;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;

        animator.SetBool("walking", !Mathf.Approximately(v.x, 0));

        // if (movementX < 0 && facingRight)
        // {
        //     transform.localScale.x *= -1;
        // }

        // facingRight = v.x >= 0f;
        // if (spriteRenderer.flipX == facingRight)
        // {
        //     spriteRenderer.flipX = !facingRight;
        // }

    }

    void OnJump()
    {
        if (touchingGround)
        {
            jumping = true;
            animator.SetBool("jumping", true);
        }
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed;
        // float YmoveDistance = movementY * speed;

        // transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
        // rb.linearVelocity = new Vector2(XmoveDistance, rb.linearVelocity.y);

        rb.linearVelocityX = XmoveDistance;
        if (touchingGround && jumping)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            jumping = false;
            animator.SetBool("jumping", false);
        }

    }

    bool touchingGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("ground"))
        // {
        //     rb.AddForce(new Vector2(0, 200));
        // }

        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingGround = false;
    }

}
