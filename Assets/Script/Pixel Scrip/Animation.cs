using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private string currentAnim;

    private enum MovementState
    { fall, idle, jump, run }

    private string[] stringState = { "Fall", "Idle", "Jump", "Run" };

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentAnim = " ";
    }

    // Update is called once per frame
    private void Update()
    {
        MovementState state;
        float move = Input.GetAxisRaw("Horizontal");

        state = move == 0 ? MovementState.idle : MovementState.run;
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        Debug.Log((int)state);
        ChangeAnim(stringState[(int)state]);
    }

    private void ChangeAnim(string animState)
    {
        if (currentAnim == animState) return;
        anim.Play(animState);
        currentAnim = animState;
    }
}