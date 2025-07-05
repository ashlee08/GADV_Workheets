using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidColourTinter : MonoBehaviour
{
    private bool toggleBlue = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleBlue = !toggleBlue;
            if (toggleBlue)
            {
                // Access the SpriteRenderer component
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                // Change the color to blue
                spriteRenderer.color = Color.blue;
            }
            else {

                // Access the SpriteRenderer component
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                // Change the color to blue
                spriteRenderer.color = Color.white;
            }
        }
    }
}
