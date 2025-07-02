using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DoTweenAnimationsUIService : MonoBehaviour
{
    [SerializeField] private float speedGlobalAnimations;
    [SerializeField] private Ease easeIn;
    [SerializeField] private UnityEvent easeOut;
    public void ToDownHideAnchcorX(float value)
    {
        var rectTransform = GetComponent<RectTransform>();
        var group = GetComponent<CanvasGroup>();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPosX(value, speedGlobalAnimations).SetEase(easeIn)).
            Join(group.DOFade(0, speedGlobalAnimations).SetEase(easeIn)).OnComplete(() => easeOut?.Invoke());
    }

    public void ToDownHideAnchcorY(float value)
    {
        var rectTransform = GetComponent<RectTransform>();
        var group = GetComponent<CanvasGroup>();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPosY(value, speedGlobalAnimations).SetEase(easeIn)).
            Join(group.DOFade(0, speedGlobalAnimations).SetEase(easeIn)).OnComplete(() => easeOut?.Invoke());
    }

    public void LvlPanelUnFade()
    {
        var rectTransform = GetComponent<RectTransform>();
        var group = GetComponent<CanvasGroup>();

        Sequence seq = DOTween.Sequence();

        seq.Append(rectTransform.DOScale(1, speedGlobalAnimations)).SetEase(easeIn).Join(group.DOFade(1, speedGlobalAnimations).SetEase(easeIn)).OnStart(()=> group.interactable = true);
    }
}
