using System.Collections;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private Transform Chest;
    
    public void SpawnChest(Transform level)
    {
            Instantiate(Chest, new Vector3(level.position.x, level.position.y, -0.22f), Quaternion.identity, level);
    }
}