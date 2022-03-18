using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    public Sprite[] enemySprites;

    private void Start()
    {
        SpawnMobs();
    }

    private void SpawnMobs()
    {
        Instantiate(enemy);
    }
}