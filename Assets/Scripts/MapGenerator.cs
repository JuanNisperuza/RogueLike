using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance;
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject currentCandy;
    public int xSize, ySize;
    private GameObject[,] levels;
    public Transform grid;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CreateInitialBoard(new Vector2(24.5f, 14f));
    }

    private void CreateInitialBoard(Vector2 offset)
    {
        levels = new GameObject[xSize, ySize];
        float startX = this.transform.position.x;
        float startY = this.transform.position.y;

        int idx = 0;
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject newLevel = Instantiate(currentCandy,
                    new Vector3(startX + (offset.x * x), startY + (offset.y * y), 1), currentCandy.transform.rotation);
                idx++;
                newLevel.GetComponent<Level>().id = idx;
                newLevel.GetComponent<Level>().sizeX = xSize;
                newLevel.GetComponent<Level>().sizeY = ySize;
                newLevel.name = string.Format("Level,[{0}],[{1}]", x, y);
                newLevel.transform.parent = grid.transform;
                levels[x, y] = newLevel;
            }
        }
    }
}