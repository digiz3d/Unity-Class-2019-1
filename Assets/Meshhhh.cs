using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshhhh : MonoBehaviour
{
    public int xSize, zSize;

    Vector3[] vertices;
    // Start is called before the first frame update
    void Start()
    {
        Mesh m = new Mesh();
        GetComponent<MeshFilter>().mesh = m;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        int i = 0;
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, Mathf.PerlinNoise((float)x/10, (float)z/10), z);
                i++;
            }
        }

        int[] triangles = new int[xSize * zSize * 6];
        i = 0;
        int vert = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[i + 0] = vert;
                triangles[i + 1] = vert + xSize + 1;
                triangles[i + 2] = vert + 1;

                triangles[i + 3] = vert + 1;
                triangles[i + 4] = vert + xSize + 1;
                triangles[i + 5] = vert + xSize + 2;

                i += 6;
                vert++;
            }
            vert++;
        }

        m.Clear();
        m.vertices = vertices;
        m.triangles = triangles;
        m.RecalculateNormals();


    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
    }
}
