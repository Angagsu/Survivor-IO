using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private GameObject gameOverPanel;

    void Update()
    {
        if (player.IsDead)
        {
            foreach (var enemy in enemies)
            {
                enemy.enabled = false;
            }
            gameOverPanel.SetActive(true);
        }
    }
}
