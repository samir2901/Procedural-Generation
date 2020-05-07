using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256, height = 256, depth = 5;
    public float scale = 11f;
    public float offsetX = 0f, offsetY = 0f;
    Terrain terrain;
    private void Start()
    {
        terrain = GetComponent<Terrain>();
        offsetX = Random.Range(0f, 9999f) + Time.deltaTime;
        offsetY = Random.Range(0f, 9999f) + Time.deltaTime;        
    }

    void Update()
    {
        terrain.terrainData = GenerateTerrainData(terrain.terrainData);
        offsetX += Time.deltaTime;
        offsetY += Time.deltaTime;        
    }

    TerrainData GenerateTerrainData(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width;
                float yCoord = (float)y / height;
                float s = Mathf.PerlinNoise(xCoord * scale + offsetX, yCoord * scale + offsetY);
                heights[x, y] = s;
            }
        }
        return heights;
    }
}
