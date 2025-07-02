using UnityEngine;

public abstract class TriggerZoneItem : IInteractable
{
    [SerializeField] protected bool isTrigger;

    public void Interact()
    {
        Debug.Log("TriggerZone");
        if (!isTrigger) return;
        isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;

        Interact();
    }
}
