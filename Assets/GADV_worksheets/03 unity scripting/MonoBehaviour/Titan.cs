using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Titan-01: Initial boot sequence initiated.");
    }

    void Start()
    {
        Debug.Log("Titan-01: Power core stable. Ready for action.");
    }

    void Update()
    {
        Debug.Log("Titan-01: Scanning for threats...");
    }

    // FixedUpdate() → "Titan-01: Running periodic stability checks."
    void FixedUpdate()
    {
        Debug.Log("Titan-01: Running periodic stability checks.");
    }

    // LateUpdate() → "Titan-01: Adjusting targeting systems."
    void LateUpdate()
    {
        Debug.Log("Titan-01: Adjusting targeting systems.");
    }


}
