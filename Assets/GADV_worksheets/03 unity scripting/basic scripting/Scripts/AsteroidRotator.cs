using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Default rotation speed
    public float rateOfChangeSpeed = 2f;
    private float changeSpeed = 0;
    void Update()
    {
        // in Radians 2Pi means 360 degrees, so we can use it to oscillate the rotation speed
        changeSpeed += Mathf.PI * rateOfChangeSpeed * Time.deltaTime; // Increment changeSpeed by a small amount each frame
        // clamp change speed between 0 to 2pi
        if (changeSpeed > 2 * Mathf.PI) changeSpeed = 0; // Reset changeSpeed to 0 after a full cycle

        // Exercise 2b + 2a, Sin part goes from -1 to 1, then we can ssee the speed changing from -rotationSpeed to +rotationSpeed
        /// at the same time we get to see the clockwise and counter-clockwise rotation
        // Use Mathf.Sin to oscillate the rotation speed between -rotationSpeed and +rotationSpeed
        float rotationSpeedv2 = Mathf.Sin(changeSpeed) * rotationSpeed; // Oscillate between -30 and +30 degrees per second
        // rotationSpeed * Time.deltaTime > 0 Clockwise rotation, < 0 Counter-clockwise rotation
        // Rotate the asteroid continuously
        transform.Rotate(0, 0, rotationSpeedv2 * Time.deltaTime);
    }
}
