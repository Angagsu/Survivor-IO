using UnityEngine;


public static class Helper 
{
    public static Enemy FindNearestEnemy(EnemySpawner enemySpawner, Transform source)
    {
        Enemy nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (var enemy in enemySpawner.SpawnedEnemies)
        {
            float distance = (enemy.transform.position - source.position).magnitude;
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }

        return nearestEnemy;
    }
}
