using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteractableController : MonoBehaviour
{
    public UnityEvent<string[]> NewButtonsActions;
    public static Transform PutPoint;
    [SerializeField] private Transform putpoint;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float distance;
    private ActionItem currentActionItem = null;
    private string[] buttons;
    public string[] Buttons
    {
        get
        {
            return buttons;
        }
        set
        {
            buttons = value;
            NewButtonsActions?.Invoke(value);
        }
    }
    private void Start()
    {
        PutPoint = putpoint;
    }

    public void Interactable(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, distance))
            if (hitInfo.transform.TryGetComponent(out Interactable component))
            {
                component.Interact();
            }
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
            if (hitInfo.transform.TryGetComponent(out Interactable component))
            {
                if(component is ActionItem item)
                {
                    currentActionItem = item;
                    currentActionItem.Action();
                    Buttons = currentActionItem.GetActionButton();
                }
            }
            else
            {
                currentActionItem?.Deaction();
                currentActionItem = null;
                Buttons = null;
            }
        else
        {
            currentActionItem?.Deaction();
            currentActionItem = null;
            Buttons = null;
        }
    }
}
