using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTerrain2d : MonoBehaviour
{
    [SerializeField] GameObject dirt, grass, stone;
    [SerializeField] int width, height, minHeightOffset, maxHeightOffset;    
    public void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            int minHeight = height - minHeightOffset;
            int maxHeight = height + maxHeightOffset;
            int h = Random.Range(minHeight, maxHeight);

            int minStoneHeight = h - 5;
            int maxStoneHeight = h - 6;
            int totalStoneDistance = Random.Range(minStoneHeight, maxStoneHeight);
            for (int y = 0; y < h; y++)
            {
                if (y < totalStoneDistance)
                {
                    addTile(stone, new Vector2(x, y));
                }
                else
                {
                    addTile(dirt, new Vector2(x, y));
                }
            }
            addTile(grass, new Vector2(x, h));
        }
    }

    public void Reset()
    {
        foreach(Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    private void addTile(GameObject tile, Vector2 position)
    {
        GameObject tileObj = Instantiate(tile, position, Quaternion.identity);
        tileObj.transform.parent = transform;
    }
    
}
