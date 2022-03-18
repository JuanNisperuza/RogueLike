using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public EnemySpawnController enemyController;
    private Player player;
    public  int health = 2;
    public  int speed = 1;
    public int damage;

    enum EasyEnemies{ bat, smoll };
    enum MediumEnemies { };
    enum HardEnemies { };

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        player = FindObjectOfType<Player>().GetComponent<Player>();
        enemyController = FindObjectOfType<EnemySpawnController>().GetComponent<EnemySpawnController>();
        SelectTypeOfEnemy();
    }

    public void SelectTypeOfEnemy()
    {
        float random = Random.Range(1, 3);
        Debug.Log(random);
        if (random == 1)
        {
            gameObject.AddComponent<Bat>();
        }
        if (random == 2)
        {
            gameObject.AddComponent<Smoll>();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //poner color rojo por medio segundo
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("se murio");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            Debug.Log("The enemy make damage");
        }
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(player.damage);
            Debug.Log("The enemy take damage");
        }
    }
}