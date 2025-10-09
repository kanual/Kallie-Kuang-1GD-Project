using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movementX;
    float movementY;
    [SerializeField] float speed = 50;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;

        Debug.Log("onmove working " + movementX);
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;

        // transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);

        rb.linearVelocity = new Vector2(XmoveDistance, rb.linearVelocity.y);
        // rb.linearVelocity = new Vector2(100, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("ground"))
        // {
        //     rb.AddForce(new Vector2(0, 200));
        // }
    }

}
