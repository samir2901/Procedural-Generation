using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInfiniteTerrain : MonoBehaviour
{
    public int heightScale = 5;
    public float detailScale = 5.0f;
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for(int v = 0; v < vertices.Length; v++)  
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + transform.position.x) / detailScale, (vertices[v].z + transform.position.z) / detailScale) * heightScale;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        gameObject.AddComponent<MeshCollider>();
    }
}
