using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int health = 2;
    public bool isPowerShot;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * 12;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}