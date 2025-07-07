using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public float health = 20;

    void OnCollisionEnter(Collision collision)
    {
        // apply collision damage
        if (collision.relativeVelocity.magnitude > 0.5)
        {
            health -= collision.relativeVelocity.magnitude;
        }

        if (health <= 0) // destroy if health is too low
        {
            Destroy(gameObject);
            // restart the scene if this was the last box
            GameObject[] boxes =
    GameObject.FindGameObjectsWithTag("Box");
            if (boxes.Length <= 1)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
