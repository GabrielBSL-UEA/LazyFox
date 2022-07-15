using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float forceOnFalling;
    [SerializeField] private float fallingSpeedLimit;

    private float currentDirection;

    private Rigidbody2D rb2D;
    private int Jumps = 2;
    private bool isJumping;

    private AudioSource audioSource;

    private void Awake()
    {
        TryGetComponent(out rb2D);
        TryGetComponent(out audioSource);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(currentDirection * speed, Mathf.Min(rb2D.velocity.y > 0 ? rb2D.velocity.y : rb2D.velocity.y * forceOnFalling, fallingSpeedLimit));
    }

    public void SetDirection(float value)
    {
        currentDirection = value;
    }

    public void TryJumping()
    {
        if (Jumps < 1)
        {
            return;
        }

        audioSource.Play();
        Jumps--;
        isJumping = true;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void TryResetJumping()
    {
        if(rb2D.velocity.y > .1f)
        {
            return;
        }

        isJumping = false;
        Jumps = 2;
    }
}
