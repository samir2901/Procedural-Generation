using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256, height = 256;
    public float scale = 11f;
    public float offsetX = 0f, offsetY = 0f;
    Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                float xCoord = (float)i / width;
                float yCoord = (float)j / height;
                float s = Mathf.PerlinNoise(xCoord * scale + offsetX, yCoord * scale + offsetY);
                Color color = new Color(s,s,s);
                texture.SetPixel(i, j, color);
            }
        }
        texture.Apply();
        return texture;
    }
}
