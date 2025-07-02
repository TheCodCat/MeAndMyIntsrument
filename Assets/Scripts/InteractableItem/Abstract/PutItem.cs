using Fusion;
using System.Collections;
using UnityEngine;

public abstract class PutItem : MonoBehaviour, IInteractable
{
    [SerializeField] protected float speed;
    protected bool isPut;
    public Rigidbody rb { get; private set; }
    private Coroutine coroutine;

    public void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Interact()
    {
        isPut = !isPut;
        rb.isKinematic = isPut;

        if (isPut)
        {
            coroutine = StartCoroutine(MoverPut());
        }
        else
            if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator MoverPut()
        {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerInteractableController.PutPoint.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, PlayerInteractableController.PutPoint.rotation, speed * Time.deltaTime);
            yield return null;
        }
    }
}
