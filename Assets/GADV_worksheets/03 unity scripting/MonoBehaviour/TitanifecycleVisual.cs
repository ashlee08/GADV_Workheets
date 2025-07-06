using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanifecycleVisual : MonoBehaviour
{
    public Color activationColor;
    private SpriteRenderer spriteRenderer;
    private float moveSpeed = 2f;  // Speed of horizontal movement
    private float moveLimit = 3f;  // Maximum distance from start pos
    private Vector3 startPos;
    private int direction = 1;  // 1 = right, -1 = left

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = activationColor;

        Debug.Log("Awake: Titan-01 is configured.");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Scale up the sprite’s width and height to 1.25 times.
        transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);

        Debug.Log("Start: Titan-01 scaled for action.");


    }

    // Update is called once per frame
    void Update()
    {
        // Move left and right to simulate patrolling
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        // Check if the sprite needs to change direction
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveLimit)
        {
            direction *= -1; // Reverse direction
        }

        Debug.Log("Update: Titan-01 patrolling...");

    }
}
