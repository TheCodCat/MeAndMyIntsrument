using UnityEngine;
using UnityEngine.InputSystem;

public class LearnPutActionItem : PutActionItem
{
    [SerializeField] private AudioSource audioSource;

    public override void ActionInteract(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
            audioSource.Play();
    }
}
