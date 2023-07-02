using UnityEngine;


class RocketLauncher : MonoBehaviour
{
    [SerializeField] private float launchInterval;
    [SerializeField] private Rocket rocketPrefab;
    [SerializeField] private float launchSpeed;
    private EnemySpawner enemySpawner;

    private float launcherTimer;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {
        launcherTimer += Time.deltaTime;
        if (launcherTimer >= launchInterval)
        {
            launcherTimer = 0;

            Enemy nearestEnemy = Helper.FindNearestEnemy(enemySpawner, transform);

            if (nearestEnemy)
            {
                Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
                Rocket rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
                rocket.Launch(direction * launchSpeed);
            }
        }
    }
}