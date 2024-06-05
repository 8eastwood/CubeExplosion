using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 150f;
    [SerializeField] private ParticleSystem _effect;

    private void OnMouseDown()
    {
        Explode();
    }

    private void Explode()
    {
        foreach (Rigidbody expodableObject in GetExplodableObjects())
        {
            expodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> objectsToExplode = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                objectsToExplode.Add(hit.attachedRigidbody);
            }
        }

        return objectsToExplode;
    }
}
