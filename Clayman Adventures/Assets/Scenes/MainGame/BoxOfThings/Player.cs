using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 4f;
    bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");



        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
