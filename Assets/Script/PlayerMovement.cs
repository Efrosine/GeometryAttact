using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSoeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask jumableGround;

    [SerializeField] private Joystick joystick;

    private Rigidbody2D rigidbody;
    private BoxCollider2D coll;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        var movement = 0f;
        if (joystick.Horizontal >= .2f)
        {
            movement = 1f;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            movement = -1f;
        }
        else
        {
            movement = 0f;
        }

        if (joystick.Vertical >= .5f && isGrounded())
        {
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSoeed;
    }

    private void moveCharacter(Vector2 direction)
    {
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);
    }
}