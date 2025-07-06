using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicCube : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material = redMaterial; // Start as red (not colliding)
    }

    void OnCollisionEnter(Collision collision)
    {
        cubeRenderer.material = greenMaterial; // Turn green when something hits it
    }

    void OnCollisionExit(Collision collision)
    {
        cubeRenderer.material = redMaterial; // Turn back to red when nothing is touching
    }
}
