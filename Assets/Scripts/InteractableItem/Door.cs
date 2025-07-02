using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private bool isOpen;
    [Header("Анимации: открытие/закрытие")]
    [SerializeField] private Animator animator;

    public void Interact()
    {
        isOpen = !isOpen;
        director.Play();
        animator.SetBool("isOpen", isOpen);
    }
}
