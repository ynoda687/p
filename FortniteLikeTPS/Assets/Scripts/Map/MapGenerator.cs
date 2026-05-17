using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public int width = 20;
    public int height = 20;
    public float tileSize = 2f;
    public float wallChance = 0.15f;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * tileSize, 0, z * tileSize);
                Instantiate(floorPrefab, pos, Quaternion.identity, transform);

                if (Random.value < wallChance)
                {
                    Vector3 wallPos = pos + new Vector3(0, 1, 0);
                    Instantiate(wallPrefab, wallPos, Quaternion.identity, transform);
                }
            }
        }
    }
}

