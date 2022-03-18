using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform[] powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Opening Chest!");
            SpawnRandom();
            Destroy(gameObject, 0.1f);
        }
    }
    private void SpawnRandom()
    {
        int random = Random.Range(0, powerUp.Length);
        Instantiate(powerUp[random], new Vector3(transform.position.x + 0.5f, transform.position.y, -0.22f), Quaternion.identity);
    }

}