using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class LearnExitDoor : ActionItem
{
    [SerializeField] private SceneAsset sceneAsset;

    public override void Interact(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            ServiceLocator.Instance.Get<HideService>().Hide(() =>
            ServiceLocator.Instance.Get<SceneService>().ChangeSceneName(sceneAsset.name));
    }
}
