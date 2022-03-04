using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    string currentAnim;
    enum MovementState { fall, idle, jump, run }
    string[] stringState = { "Fall", "Idle", "Jump", "Run" };

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentAnim = " ";
    }

    // Update is called once per frame
    void Update()
    {
        MovementState state;
        float move = Input.GetAxisRaw("Horizontal");

        state = move == 0 ? MovementState.idle : MovementState.run;
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        Debug.Log((int)state);
        ChangeAnim(stringState[(int)state]);
    }

    void ChangeAnim(string animState)
    {
        if (currentAnim == animState) return;
        anim.Play(animState);
        currentAnim = animState;
    }
}
