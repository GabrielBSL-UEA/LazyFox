using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;

    private bool isRight;
    private bool automaticAnimation = true;

    private void Awake()
    {
        TryGetComponent(out animator);
        TryGetComponent(out rb2D);
    }

    private void FixedUpdate()
    {
        if (!automaticAnimation)
        {
            return;
        }

        if(rb2D.velocity == Vector2.zero)
        {
            animator.Play("foxIdle");
        }
        else if(Mathf.Abs(rb2D.velocity.y) < .1f)
        {
            animator.Play("foxWalk");
        }
        else if(rb2D.velocity.y > 0)
        {
            animator.Play("foxUp");
        }
        else
        {
            animator.Play("foxDown");
        }
    }

    public void SetRotationByDirection(float value)
    {
        if(value > 0 && !isRight)
        {
            isRight = true;
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (value < 0 && isRight)
        {
            isRight = false;
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
