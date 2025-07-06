using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPlayer : MonoBehaviour
{
    CharacterController controller;

    // Your variables used for moving the player
    public float speed = 5.0f;     // Movement speed
    public float radius = 5.0f;    // Explosion radius
    public float power = 100.0f;   // Explosion force (100 recommended for mass 1)
    public float kickStrength = 10.0f; // Set this in the Inspector
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false; // Optional, disable collisions if needed
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Kick();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckExplosion();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        
        
    }

    void Kick()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * kickStrength, ForceMode.Impulse);
            }
        }
        
            
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        controller.SimpleMove(move * speed);
    }

    void CheckExplosion()
    {
    
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, 1.0f, ForceMode.Impulse);
            }
        }
        
    }
}
