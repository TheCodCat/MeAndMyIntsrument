using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public abstract class PutActionItem : PutItem
{
    [SerializeField] private InputActionReference actionReference;

    public void OnDisable()
    {
        if (actionReference == null) return;

        actionReference.action.Disable();

        actionReference.action.started -= ctx => ActionInteract(ctx);
        actionReference.action.performed -= ctx => ActionInteract(ctx);
        actionReference.action.canceled -= ctx => ActionInteract(ctx);
    }

    public override void Interact()
    {
        base.Interact();

        if (isPut)
        {
            if (actionReference == null) return;

            actionReference.action.Enable();

            actionReference.action.started += ctx => ActionInteract(ctx);
            actionReference.action.performed += ctx => ActionInteract(ctx);
            actionReference.action.canceled += ctx => ActionInteract(ctx);
        }
        else
        {
            if (actionReference == null) return;

            actionReference.action.Disable();

            actionReference.action.started -= ctx => ActionInteract(ctx);
            actionReference.action.performed -= ctx => ActionInteract(ctx);
            actionReference.action.canceled -= ctx => ActionInteract(ctx);
        }

    }

    public virtual void ActionInteract(InputAction.CallbackContext callbackContext)
    {

    }
}
