using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
   [System.Serializable]
   public class Wave
    {
        public Enemy EnemyPrefab;
        public float SpawnTime;
        public int MinCount;
        public int MaxCount;
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private float spawnRadius;
    [SerializeField] private Transform centerOfSpawnRadius;

    private int waveIndex;
    private Wave currentWave => waves[waveIndex];
    private bool hasWaves => waveIndex < waves.Length;

    public List<Enemy> SpawnedEnemies { get; } = new List<Enemy>();

    private void Update()
    {
        if (hasWaves && Time.timeSinceLevelLoad > currentWave.SpawnTime)
        {
            Spawn();
            waveIndex++;
        }
    }

    private void Spawn()
    {
        int count = UnityEngine.Random.Range(currentWave.MinCount, currentWave.MaxCount);

        for (int i = 0; i < count; i++)
        {
            var position = centerOfSpawnRadius.position + (Vector3)UnityEngine.Random.insideUnitCircle * spawnRadius;
            var enemy = Instantiate(currentWave.EnemyPrefab, position, Quaternion.identity);
            SpawnedEnemies.Add(enemy);
        }
    }
}
