using UnityEngine;
using UnityEngine.InputSystem;

public class ExecuterFireController : PutActionItem
{
    [SerializeField] private ParticleSystem _particleSystem;

    public override void ActionInteract(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            _particleSystem.Play();
        else if(callbackContext.canceled)
            _particleSystem.Stop();
    }
}
