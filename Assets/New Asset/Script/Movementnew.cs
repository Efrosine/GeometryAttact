using System.Collections;
using UnityEngine;

public class Movementnew : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;

    [SerializeField] private float speed, jumpForce, addGrav;
    [SerializeField] private LayerMask ground, trap;

    private float inter = 0f;
    private bool isBlinking, isTakingDamage, isDamaged;

    private Healt playerHealt;
    
    [SerializeField] Sprite[] sprite;

    // Start is called before the first frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        playerHealt = GetComponent<Healt>();
        isBlinking = false;
        isTakingDamage = false;
        isDamaged = false;
    }

    // Update is called once per frame
    private void Update()
    {
        inter += .1f * Time.deltaTime;
        float gravity = Mathf.Lerp(1, addGrav, inter);
        rb.gravityScale = rb.velocity.y < -.1f ? gravity : 1;
       
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    

    private IEnumerator blink(float counter)
    {
        isBlinking = true;
        float time = 0;
        while (time < counter)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
            yield return new WaitForSeconds(.1f);
            time += Time.deltaTime + .2f;
        }
        isBlinking = false;
    }

 

    private IEnumerator takeDamage()
    {
        isTakingDamage = true;
        while (isDamaged)
        {
            playerHealt.getHit(20f);
            yield return new WaitForSeconds(1f);
        }
        isTakingDamage = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isDamaged = true;
            if (!isTakingDamage) StartCoroutine(takeDamage());

            RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, trap);
            if (hit)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isBlinking)
        {
            StartCoroutine(blink(2f));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isDamaged = false;
        }
    }
}