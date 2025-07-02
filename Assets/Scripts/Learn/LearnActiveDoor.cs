using Assets.Scripts.InteractableItem.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class LearnActiveDoor :MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector nextPlayableDirector;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpenExecute;
    public void Interact()
    {
        if(isOpenExecute)
            animator.SetTrigger("Open");
    }

    public void ActiveIsOpen()
    {
        isOpenExecute = true;
    }
}
