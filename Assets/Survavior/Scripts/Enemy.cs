using UnityEngine;

public class Enemy : Character
{

    private Transform target;
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
