using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookAtController : MonoBehaviour, IEscExecute
{
    [SerializeField] private Transform body;
    [SerializeField] private Transform cameratransform;
    [SerializeField] private float sensity;
    [SerializeField, Range(0,90)] private float maxAngle;
    [field : SerializeField] public bool IsExecute { get; set; } = true;
    public Vector2 delta;

    private void OnEnable()
    {
        PlayerCursorController.ChangeEsc += GetEsc;
    }

    private void OnDisable()
    {
        PlayerCursorController.ChangeEsc -= GetEsc;
    }

    public void LookAt(InputAction.CallbackContext callbackContext)
    {
        if (!IsExecute) return;

        delta += callbackContext.ReadValue<Vector2>() * sensity;
        delta.y = Mathf.Clamp(delta.y, -maxAngle,maxAngle);
        body.rotation = Quaternion.Euler(0,delta.x,0);
        cameratransform.localRotation = Quaternion.Euler(-delta.y,0,0);
    }

    public void GetEsc(bool value)
    {
        IsExecute = !value;
    }
}
