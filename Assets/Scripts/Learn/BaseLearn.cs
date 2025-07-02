using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public abstract class BaseLearn: MonoBehaviour, IEscExecute
{
    public InputActionReference inputActionReference;
    [SerializeField] private PlayableDirector nextPlayableDirector;

    public bool IsExecute { get; set; } = true;

    private void OnEnable()
    {
        PlayerCursorController.ChangeEsc += GetEsc;
    }

    private void OnDisable()
    {
        PlayerCursorController.ChangeEsc -= GetEsc;
    }

    public virtual void ActiveInput()
    {
        inputActionReference.action.Enable();
        inputActionReference.action.started += ctx => GetInputLearn(ctx);
        inputActionReference.action.performed += ctx => GetInputLearn(ctx);
        inputActionReference.action.canceled += ctx => GetInputLearn(ctx);
    }

    public virtual void DeActiveInput()
    {
        inputActionReference.action.Disable();
        inputActionReference.action.started -= ctx => GetInputLearn(ctx);
        inputActionReference.action.performed -= ctx => GetInputLearn(ctx);
        inputActionReference.action.canceled -= ctx => GetInputLearn(ctx);
    }

    public virtual void GetInputLearn(InputAction.CallbackContext callbackContext)
    {
        if (!IsExecute) return;

        nextPlayableDirector.Play();
        DeActiveInput();
    }

    public void GetEsc(bool value)
    {
        IsExecute = !value;
    }
}
