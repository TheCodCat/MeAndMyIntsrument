using UnityEngine;

public class FireBlock : PutItem
{
    [SerializeField] private float mulltiple;
    private Vector3 currentScale;

    private void Start()
    {
        currentScale = transform.localScale;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentScale -= Vector3.one * mulltiple;

        Debug.Log("asdasd");

        transform.localScale = currentScale;

        if(currentScale.x <= 0.2)
            Destroy(gameObject);
    }
}
