using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
    }

    public virtual void Interact(Action action)
    {
        action?.Invoke();
    }

    public virtual void Interact(InputAction.CallbackContext callbackContext)
    {

    }
}
