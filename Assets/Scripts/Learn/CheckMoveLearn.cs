using Assets.Scripts.Learn;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckMoveLearn : BaseLearn
{
    [SerializeField] private LearnResult<float> learnResult;
    [SerializeField] private LearnResult<float> currentLearnResult;
    public override void GetInputLearn(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;

        currentLearnResult.Value += callbackContext.ReadValue<Vector2>().sqrMagnitude;
        if(currentLearnResult.Value >= learnResult.Value)
            base.GetInputLearn(callbackContext);
    }
}
