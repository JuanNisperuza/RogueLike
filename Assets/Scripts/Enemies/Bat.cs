using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Enemy enemy;
    public bool moveToPlayer = true;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        SetStats();
        SetSprite();
    }

    private void Update()
    {
        if (moveToPlayer && enemy.playerTransform)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.playerTransform.position, enemy.speed * Time.deltaTime);
            if (transform.position == enemy.playerTransform.position)
            {
                moveToPlayer = false;
            }
        }
    }

    private void SetStats()
    {
        enemy.speed = 5;
        enemy.health = 2;
        enemy.damage = 1;
    }

    private void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.enemyController.enemySprites[0];
    }

}
