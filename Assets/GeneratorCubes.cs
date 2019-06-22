using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCubes : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject SCube, MCube, TCube, QCube;

    // Start is called before the first frame update
    void Start()
    {
        for(int x=0; x<xSize; x++)
        {
            for (int z = 0; z < ySize; z++)
            {
                GameObject nextObject;
                float p = Mathf.PerlinNoise((float)x/xSize, (float)z/xSize);
                if (p < 0.3)
                {
                    nextObject = SCube;
                }
                else if(p<0.4f)
                {
                    nextObject = MCube;
                }
                else if(p<0.5f)
                {
                    nextObject = TCube;
                }
                else
                {
                    nextObject = QCube;
                }
                
                Instantiate(nextObject, new Vector3(x, 0, z), Quaternion.identity, transform);
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
