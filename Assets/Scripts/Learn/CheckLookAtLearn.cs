using Assets.Scripts.Learn;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckLookAtLearn : BaseLearn
{
    [SerializeField] private float multiple;
    [SerializeField] private LearnResult<float> LearnResult;
    [SerializeField] private LearnResult<float> currentLearnResult;

    private void Start()
    {
        LearnResult.Value = 1;
    }

    public override void GetInputLearn(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            currentLearnResult.Value += callbackContext.ReadValue<Vector2>().SqrMagnitude() * multiple;

            if(currentLearnResult.Value >= LearnResult.Value)
                base.GetInputLearn(callbackContext);
        }

    }
}
