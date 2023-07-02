using UnityEngine;


public class Damager : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] protected bool destroyOnHit;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (TryToDamage(collision) && destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    protected bool TryToDamage(Collider2D collision)
    {
        bool hasHealth = collision.TryGetComponent<Character>(out var character);
        bool otherHealth = !collision.CompareTag(tag);

        if (hasHealth && otherHealth)
        {
            character.TakeDamage(damage);
            return true;
        }

        return false;
    }
}
