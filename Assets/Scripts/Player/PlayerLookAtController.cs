using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookAtController : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private Transform cameratransform;
    [SerializeField] private float sensity;
    [SerializeField, Range(0,90)] private float maxAngle;
    private Vector2 delta;

    public void LookAt(InputAction.CallbackContext callbackContext)
    {
        delta += callbackContext.ReadValue<Vector2>() * sensity;
        delta.y = Mathf.Clamp(delta.y, -maxAngle,maxAngle);
        body.rotation = Quaternion.Euler(0,delta.x,0);
        cameratransform.localRotation = Quaternion.Euler(-delta.y,0,0);
    }
}
