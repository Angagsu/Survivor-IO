using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject gameOverPanel;


    void Update()
    {
        if (player.IsDead)
        {
            foreach (var enemy in enemySpawner.SpawnedEnemies)
            {
                enemy.enabled = false;
            }
            gameOverPanel.SetActive(true);
        }
    }
}
