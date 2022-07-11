using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [SerializeField] private float speed;

    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rigidbody2D;

    private bool isLeft = true;
    public LayerMask groundLayerMask;

    private void Awake()
    {
        TryGetComponent(out boxCollider2d);
        TryGetComponent(out rigidbody2D);
    }

    private void FixedUpdate()
    {
        float walkDirection = isLeft ? -1 : 1;
        rigidbody2D.velocity = Vector2.right * speed * walkDirection;

        Vector2 direction = new Vector2(isLeft ? -boxCollider2d.bounds.extents.x : boxCollider2d.bounds.extents.x, 0);
        var hit = Physics2D.Raycast((Vector2) boxCollider2d.bounds.center + direction, Vector2.down, boxCollider2d.bounds.extents.y + 1, groundLayerMask);

        if (!hit)
        {
            isLeft = !isLeft;
            float newAngle = isLeft ? 0 : 180;
            transform.eulerAngles = new Vector2(0, newAngle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<GameController>().ActivateDefeatPanel();
        }
    }
}
