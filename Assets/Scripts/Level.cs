using UnityEngine;

public class Level : MonoBehaviour
{
    public int id;
    public Vector2 levelPosition;
    private GameObject leftDoor;
    private GameObject rightDoor;
    private GameObject upDoor;
    private GameObject downDoor;
    public ItemsSpawner spawner;
    public int sizeX;
    public int sizeY;
    public float levelArea;
    private int chestProbablility = 4;
    private bool limitLevel;

    private void Start()
    {
        FindDoors();
        SetIfIsALimit();
        spawner = GameObject.Find("ItemsSpawner").GetComponent<ItemsSpawner>();
        SetLevelChest();
    }

    public void SetLevelChest()
    {
        int randomValue = Random.Range(0, 6);
        if(randomValue > chestProbablility && !limitLevel) 
        {
            spawner.SpawnChest(transform);
        }
        
    }

    public void SetIfIsALimit()
    {
        string position = this.gameObject.name;
        position = position.Replace("[", "");
        position = position.Replace("]", "");
        string[] str = position.Split(",".ToCharArray());
        levelPosition.x = int.Parse(str[1]);
        levelPosition.y = int.Parse(str[2]);
        limitLevel = IsLimits();
    }

    public bool IsLimits()
    {
        bool isLimit = false;
        if (levelPosition.y == 0)
        {
            Destroy(downDoor);
            isLimit = true;
        }
        if (levelPosition.x == 0)
        {
            Destroy(leftDoor);
            isLimit = true;
        }
        if (levelPosition.x == sizeX - 1)
        {
            Destroy(rightDoor);
            isLimit = true;
        }
        if (levelPosition.y == sizeY - 1)
        {
            Destroy(upDoor);
            isLimit = true;
        }
        return isLimit;
    }

    public void FindDoors()
    {
        foreach (Transform child in this.transform)
        {
            switch (child.name)
            {
                case "Right":
                    rightDoor = child.gameObject;
                    break;

                case "Left":
                    leftDoor = child.gameObject;
                    break;

                case "Up":
                    upDoor = child.gameObject;
                    break;

                case "Down":
                    downDoor = child.gameObject;
                    break;

                default:
                    break;
            }
        }
    }
}