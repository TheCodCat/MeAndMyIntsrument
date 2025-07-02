using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ActionItem : Interactable
{
    [SerializeField] private InputActionReference actionReference;
    private bool isAction;

    public void Action()
    {
        if (isAction) return;
        isAction = true;

        actionReference.action.Enable();

        actionReference.action.started += ctx => Interact(ctx);
        actionReference.action.performed += ctx => Interact(ctx);
        actionReference.action.canceled += ctx => Interact(ctx);
        Debug.Log("Action");
    }

    public void Deaction()
    {
        if (!isAction) return;
        isAction = false;


        actionReference?.action.Disable();

        actionReference.action.started -= ctx => Interact(ctx);
        actionReference.action.performed -= ctx => Interact(ctx);
        actionReference.action.canceled -= ctx => Interact(ctx);
        Debug.Log("DeAction");
    }

    public override void Interact(InputAction.CallbackContext callbackContext)
    {
        base.Interact();

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
        return actionReference.action.bindings[0].path.Split("/");
    }
}
