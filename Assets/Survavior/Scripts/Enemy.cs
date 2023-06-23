using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private ExperiencePickup experiencePickup;

    protected Transform target;

    protected virtual void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }
    
    protected virtual void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    protected override void OnDead()
    {
        Instantiate(experiencePickup, transform.position, Quaternion.identity);
    }
}
