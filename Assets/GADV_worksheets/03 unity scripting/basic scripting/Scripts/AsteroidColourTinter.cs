using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidColourTinter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Change the color to blue
            spriteRenderer.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
