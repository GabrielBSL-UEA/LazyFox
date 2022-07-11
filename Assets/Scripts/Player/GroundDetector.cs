using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        transform.parent.TryGetComponent(out playerController);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground"))
        {
            return;
        }

        playerController.ReceiveGroundDetectionFeedback();
    }
}
