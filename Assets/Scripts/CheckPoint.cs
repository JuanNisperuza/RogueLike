using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Healing!");
            GameManager.Instance.time += 10;
            Destroy(gameObject, 0.1f);
        }
    }
}