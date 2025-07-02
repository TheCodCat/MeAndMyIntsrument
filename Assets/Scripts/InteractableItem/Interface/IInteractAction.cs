using UnityEngine.InputSystem;

namespace Assets.Scripts.InteractableItem.Interface
{
    public interface IInteractAction : IInteractable
    {
        public InputActionReference InputActionReference { get; set; }

        public void Interact(InputAction.CallbackContext callbackContext);

        public void Action();

        public void Deaction();

        public string[] GetActionButton()
        {
            return InputActionReference.action.bindings[0].path.Split("/");
        }
    }
}
