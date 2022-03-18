using UnityEngine;

public class Door : MonoBehaviour
{
    private string direction;
    private Vector2 spawnLocation;
    Vector3 finalPosition;
    private float cameraMovementX = 0;
    private float cameraMovementY = 0;
    bool Move;

    private void Start()
    {
        direction = gameObject.name;
        SetSpawnLocation();
    }

    public void SetSpawnLocation()
    {
        switch (direction)
        {
            case "Right":
                SetRightDirection();
                break;

            case "Left":
                SetLeftDirection();
                break;

            case "Up":
                SetUpDirection();
                break;

            case "Down":
                SetDownDirection();
                break;

            default:
                Debug.LogError("Unmatch Door");
                break;
        }
    }

    public void SetRightDirection()
    {
        spawnLocation = new Vector2(transform.position.x + 5.3f, transform.position.y);
        cameraMovementX = 24.5f;
    }

    public void SetLeftDirection()
    {
        spawnLocation = new Vector2(transform.position.x - 5.3f, transform.position.y);
        cameraMovementX = -24.5f;
    }

    public void SetUpDirection()
    {
        spawnLocation = new Vector2(transform.position.x, transform.position.y + 4f);
        cameraMovementY = 14;
    }

    public void SetDownDirection()
    {
        spawnLocation = new Vector2(transform.position.x, transform.position.y - 4f);
        cameraMovementY = -14;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = spawnLocation;
            Debug.Log("Player teleported to " + direction);
            finalPosition = new Vector3(Camera.main.transform.position.x + cameraMovementX, Camera.main.transform.position.y + cameraMovementY, Camera.main.transform.position.z);
            Move = true;
        }
    }

    private void Update()
    {
        if (Move)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, finalPosition, 35 * Time.deltaTime);
            if (Camera.main.transform.position == finalPosition)
            {
                Move = false;
            }
        }
    }
   
}