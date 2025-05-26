using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Default rotation speed

    void Update()
    {
        // Rotate the asteroid continuously
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
