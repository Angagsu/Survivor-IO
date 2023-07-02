using System.Collections;
using UnityEngine;


public class Player : Character
{
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private UpgradesManager upgradesManager;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private int[] experiencesLevels;

    private float shootTimer;
    private int currentLevel;
    private int experience;
    private const float bulletsInterval = 0.2f;
    public int BulletsCount { get; set; } = 1;


    void Update()
    {
        cameraMain.transform.position = new Vector3(transform.position.x, transform.position.y, cameraMain.transform.position.z);
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
            StartCoroutine(ShootProcess());
        }
    }

    private IEnumerator ShootProcess()
    {
        for (int i = 0; i < BulletsCount; i++)
        {
            Enemy nearestEnemy = Helper.FindNearestEnemy(enemySpawner, transform);

            if (nearestEnemy)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
                rb.AddForce(direction * shootSpeed);
            }

            yield return new WaitForSeconds(bulletsInterval);
        }  
    }


    public void AddExperience(int value)
    {
        experience += value;
        var newLevel = System.Array.FindLastIndex(experiencesLevels, e => experience >= e);
        Debug.Log("Level: " + currentLevel + ", exp: " + experience);

        if (newLevel > currentLevel)
        {
            upgradesManager.SuggestToUpgrade();
            currentLevel = newLevel;
        }
    }

    [ContextMenu("Add Experience")]
    void AddExperience()
    {
        AddExperience(5);
    }

    [ContextMenu("ResetExperience")]
    void ResetExperience()
    {
        currentLevel = experience = 0;
    }
}
