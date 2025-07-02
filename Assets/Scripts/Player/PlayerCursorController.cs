using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursorController : MonoBehaviour
{
    public static Action<bool> ChangeEsc;
    [SerializeField] private InputActionReference escReference;
    [SerializeField] private RectTransform settingsPanel;
    [SerializeField] private bool isAwake;
    [SerializeField] private bool isEsc;
    public bool IsEsc
    {
        get { return isEsc; }
        set
        {
            isEsc = value;
            ChangeEsc?.Invoke(value);
        }
    }

    private void OnEnable()
    {
        escReference.action.Enable();
        escReference.action.performed += ctx => EscInput(ctx);
    }

    private void Awake()
    {
        if (!isAwake) return;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        escReference.action.Disable();
        escReference.action.performed -= ctx => EscInput(ctx);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EscInput(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;

        IsEsc = !IsEsc;

        settingsPanel.gameObject.SetActive(IsEsc ? true : false);
        Cursor.lockState = IsEsc ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = IsEsc ? true : false;
    }
}
