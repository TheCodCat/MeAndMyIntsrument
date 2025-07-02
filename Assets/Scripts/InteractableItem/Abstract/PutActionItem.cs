using Assets.Scripts.InteractableItem.Interface;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public abstract class PutActionItem : PutItem, IInteractAction
{
    [field: SerializeField] public InputActionReference InputActionReference { get; set; }

    public void OnDisable()
    {
        if (InputActionReference == null) return;

        InputActionReference.action.Disable();

        InputActionReference.action.started -= ctx => ActionInteract(ctx);
        InputActionReference.action.performed -= ctx => ActionInteract(ctx);
        InputActionReference.action.canceled -= ctx => ActionInteract(ctx);
    }

    public override void Interact()
    {
        base.Interact();
        if (isPut)
        {
            if (InputActionReference == null) return;

            InputActionReference.action.Enable();

            InputActionReference.action.started += ctx => ActionInteract(ctx);
            InputActionReference.action.performed += ctx => ActionInteract(ctx);
            InputActionReference.action.canceled += ctx => ActionInteract(ctx);
        }
        else
        {
            if (InputActionReference == null) return;

            InputActionReference.action.Disable();

            InputActionReference.action.started -= ctx => ActionInteract(ctx);
            InputActionReference.action.performed -= ctx => ActionInteract(ctx);
            InputActionReference.action.canceled -= ctx => ActionInteract(ctx);
        }

    }

    public void Interact(InputAction.CallbackContext callbackContext)
    {
    }

    public virtual void ActionInteract(InputAction.CallbackContext callbackContext)
    {

    }

    public void Action()
    {
    }

    public void Deaction()
    {
    }

}
