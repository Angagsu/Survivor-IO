using UnityEngine;

public class Player : Character
{
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Enemy[] enemies;
    private float shootTimer;
    
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 step = new Vector3(horizontal, vertical, 0);

        transform.Translate(step * moveSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Enemy nearestEnemy = FindNearestEnemy();
            Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;

            rb.AddForce(direction * shootSpeed);
        }
    }

    private Enemy FindNearestEnemy()
    {
        Enemy nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach ( var enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).magnitude;
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }

        return nearestEnemy;
    }
}
