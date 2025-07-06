using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{
    CharacterController controller;
    public Material redMaterial;
    public Material greenMaterial;
    // Your variables used for moving the player
    public float speed = 5.0f;     // Movement speed

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckLineOfSight();
    }

    void FixedUpdate()
    {
        MovePlayer();
 
    }

    
    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        controller.SimpleMove(move * speed);
    }
    void CheckLineOfSight()
    {
        /* add your code here */
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RaycastHit hitData;

        foreach (GameObject enemy in enemies)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            enemy.GetComponent<Renderer>().material = redMaterial;
            // Draw the ray in red by default
            Debug.DrawRay(transform.position, direction.normalized * 100f, Color.red);

            // Perform raycast
            if (Physics.Raycast(transform.position, direction.normalized, out hitData, 100f))
            {
                // Check if the hit object is the enemy itself
                if (hitData.collider.gameObject == enemy)
                {
                    // Change ray color to green if the enemy is visible
                    Debug.DrawRay(transform.position, direction.normalized * 100f, Color.green);
                    enemy.GetComponent<Renderer>().material = greenMaterial;
                }
            }
            
        }
    }

}
