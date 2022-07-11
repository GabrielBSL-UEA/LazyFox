using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs inputActions;

    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new PlayerInputs();

        inputActions.Player.Movement.performed += ctx => InterpretWalkInput(ctx.ReadValue<float>());
        inputActions.Player.Movement.canceled += _ => InterpretWalkInput(0);

        inputActions.Player.Jump.performed += _ => InterpretJumpInput();

        TryGetComponent(out playerAnimation);
        TryGetComponent(out playerHealth);
        TryGetComponent(out playerMovement);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InterpretWalkInput(float direction)
    {
        playerMovement.SetDirection(direction);
        playerAnimation.SetRotationByDirection(direction);
    }

    private void InterpretJumpInput()
    {
        playerMovement.TryJumping();
    }

    public void ReceiveGroundDetectionFeedback()
    {
        playerMovement.TryResetJumping();
    }
}
