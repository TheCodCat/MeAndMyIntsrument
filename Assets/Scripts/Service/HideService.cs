using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class HideService : MonoBehaviour, IService
{
	[SerializeField] private Image hideImage;
	[SerializeField] private AudioSource hideAudioSource;
	[SerializeField] private bool playOnEwake;

    private void Start()
    {
		if (playOnEwake)
			Reveal();

    }

    public void Hide(Action callback)
	{
		hideAudioSource.Play();

		hideImage.rectTransform
			.DOScale(1, hideAudioSource.clip.length).SetEase(Ease.InCubic)
			.OnComplete(() => callback?.Invoke());
	}

	public void Reveal(Action callback)
	{
        hideAudioSource.Play();

		Sequence sequence = DOTween.Sequence();

		sequence.Append(hideImage.rectTransform.DOScale(1,0f).From(1f).SetEase(Ease.Linear))
			.Append(hideImage.rectTransform
            .DOScale(0, hideAudioSource.clip.length).SetEase(Ease.InCubic)
            .OnComplete(() => callback?.Invoke()));
    }

    public void Reveal()
    {
        hideAudioSource.Play();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(hideImage.rectTransform.DOScale(1, 0f).From(1f).SetEase(Ease.Linear))
            .Append(hideImage.rectTransform
            .DOScale(0, hideAudioSource.clip.length).SetEase(Ease.InCubic));
    }
}
