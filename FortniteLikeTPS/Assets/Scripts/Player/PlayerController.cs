using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float crouchHeight = 1f;

    CharacterController controller;
    Vector3 velocity;
    float normalHeight;
    bool isGrounded;
    bool isCrouching;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        normalHeight = controller.height;
    }

    public void TickMove(Vector2 moveInput, bool jumpPressed, bool crouchHeld)
    {
        HandleMovement(moveInput);
        HandleJump(jumpPressed);
        HandleCrouch(crouchHeld);
    }

    void HandleMovement(Vector2 moveInput)
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleJump(bool jumpPressed)
    {
        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    void HandleCrouch(bool crouchHeld)
    {
        if (crouchHeld)
        {
            if (!isCrouching)
            {
                controller.height = crouchHeight;
                isCrouching = true;
            }
        }
        else
        {
            if (isCrouching)
            {
                controller.height = normalHeight;
                isCrouching = false;
            }
        }
    }
}
