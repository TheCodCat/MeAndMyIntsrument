using UnityEngine;

public abstract class TriggerZoneItem : Interactable
{
    [SerializeField] protected bool isTrigger;

    public override void Interact()
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
