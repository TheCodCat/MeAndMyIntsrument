using Assets.Scripts.InteractableItem.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ActionItem : MonoBehaviour, IInteractAction
{
    [field: SerializeField] public InputActionReference InputActionReference { get; set; }
    private bool isAction;

    public virtual void Action()
    {
        if (isAction) return;
        isAction = true;

        InputActionReference.action.Enable();

        InputActionReference.action.started += ctx => Interact(ctx);
        InputActionReference.action.performed += ctx => Interact(ctx);
        InputActionReference.action.canceled += ctx => Interact(ctx);
        Debug.Log("Action");
    }

    public virtual void Deaction()
    {
        if (!isAction) return;
        isAction = false;


        InputActionReference?.action.Disable();

        InputActionReference.action.started -= ctx => Interact(ctx);
        InputActionReference.action.performed -= ctx => Interact(ctx);
        InputActionReference.action.canceled -= ctx => Interact(ctx);
        Debug.Log("DeAction");
    }

    public virtual void Interact()
    {
    }

    public virtual void Interact(InputAction.CallbackContext callbackContext)
    {

        if (callbackContext.started)
        {
            var buttons = callbackContext.action.bindings[0].path.Split('/');
            foreach (var item in buttons)
            {
                Debug.Log($"{item}");
            }
        }
    }

    public string[] GetActionButton()
    {
        return InputActionReference.action.bindings[0].path.Split("/");
    }

}
