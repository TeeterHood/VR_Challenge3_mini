using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField] private string objectTag = "PlayerProjectile"; // The tag of the object that can trigger the hitbox.
    [SerializeField] private bool destroyParent = true; // Whether to destroy the parent GameObject instead of just the hitbox.
    [SerializeField] private GameObject prefabToDestroy; // Optional prefab to destroy instead of parent or self.

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the specified tag.
        if (other.CompareTag(objectTag))
        {
            if (prefabToDestroy != null)
            {
                // Destroy the specified prefab.
                Destroy(prefabToDestroy);
            }
            else if (destroyParent && transform.parent != null)
            {
                // Destroy the parent GameObject.
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // Destroy the hitbox GameObject (default behavior).
                Destroy(gameObject);
            }

            // Optionally, destroy the colliding object as well.
            // Destroy(other.gameObject);
        }
    }
}
