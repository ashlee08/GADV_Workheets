using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRotate : MonoBehaviour
{
    public float torqueStrength = 100f; // Adjust in Inspector
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddTorque(Vector3.up * torqueStrength, ForceMode.Impulse); // Clockwise (Y-axis)
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddTorque(-Vector3.up * torqueStrength, ForceMode.Impulse); // Anti-clockwise
        }
    }
}
