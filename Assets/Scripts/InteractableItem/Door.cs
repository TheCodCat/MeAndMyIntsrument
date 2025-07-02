using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Door : Interactable
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private bool isOpen;
    [Header("Анимации: открытие/закрытие")]
    [SerializeField] private Animator animator;

    public override void Interact()
    {
        base.Interact();

        isOpen = !isOpen;
        director.Play();
        animator.SetBool("isOpen", isOpen);
    }
}
