using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJump;
    [SerializeField] private float gravity;
    [SerializeField] private float multiply;
    private Vector3 moveDirection;

    private void Update()
    {
        if (characterController.isGrounded)
            moveDirection.y = -1;
        else
        {
            moveDirection.y += (-9.8f * Time.fixedDeltaTime);
        }
        if (characterController.isGrounded && isJump)
            moveDirection.y += Mathf.Sqrt(jumpForce * multiply * gravity);
        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }

    public void GetInputDirection(InputAction.CallbackContext callbackContext)
    {
        moveDirection.x = callbackContext.ReadValue<Vector2>().x;
        moveDirection.z = callbackContext.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        isJump = callbackContext.ReadValueAsButton();
    }
}
