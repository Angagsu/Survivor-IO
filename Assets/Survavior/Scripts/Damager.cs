using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool destroyOnHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasHealth = collision.TryGetComponent<Character>(out var character);
        bool otherHealth = !collision.CompareTag(tag);

        if (hasHealth && otherHealth)
        {
            character.TakeDamage(damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}
