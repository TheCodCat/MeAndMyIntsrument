using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public abstract class BaseLearn: MonoBehaviour
{
    public InputActionReference inputActionReference;
    [SerializeField] private PlayableDirector nextPlayableDirector;
    public void ActiveInput()
    {
        inputActionReference.action.Enable();
        inputActionReference.action.started += ctx => GetInputLearn(ctx);
        inputActionReference.action.performed += ctx => GetInputLearn(ctx);
        inputActionReference.action.canceled += ctx => GetInputLearn(ctx);
    }

    public void DeActiveInput()
    {
        inputActionReference.action.Disable();
        inputActionReference.action.started -= ctx => GetInputLearn(ctx);
        inputActionReference.action.performed -= ctx => GetInputLearn(ctx);
        inputActionReference.action.canceled -= ctx => GetInputLearn(ctx);


    }

    public virtual void GetInputLearn(InputAction.CallbackContext callbackContext)
    {
        nextPlayableDirector.Play();
        DeActiveInput();
    }
}
