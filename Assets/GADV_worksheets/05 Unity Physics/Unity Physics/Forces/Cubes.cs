using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StackCubes(Vector3.zero, 8, 8, 8);
    }

    void StackCubes(Vector3 position, int nx, int ny, int nz)
    {
        // Create stacked cube at the specified position using nx ny nz
        for (int x = 0; x < nx; x++)
        {
            for (int y = 0; y < ny; y++)
            {
                for (int z = 0; z < nz; z++)
                {
                    // ensure the cube doesnt overlap with the previous cubes
                    // by offsetting the position by 1 unit in each direction
                    // This will create a grid of cubes in the specified dimension

                    Vector3 cubePosition = position + new Vector3(x, y, z) * 1.1f;
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = cubePosition;
                    // attach rigidbody to the cube
                    Rigidbody rb = cube.AddComponent<Rigidbody>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
