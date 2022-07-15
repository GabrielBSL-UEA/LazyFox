using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        coroutine = WaitAndPrint(5.0f);
        StartCoroutine(coroutine);
        
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dirX = dirX * -1f;
    }
}
