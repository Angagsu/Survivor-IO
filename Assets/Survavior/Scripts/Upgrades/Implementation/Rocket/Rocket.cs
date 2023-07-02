using UnityEngine;


public class Rocket : Damager
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float aoeRadius;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, aoeRadius);
        bool anyDamaged = false;
        foreach (var target in targets)
        {
            anyDamaged |= TryToDamage(target);
        }

        if (anyDamaged && destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector3 direction)
    {
        rb.AddForce(direction);
        transform.up = direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
