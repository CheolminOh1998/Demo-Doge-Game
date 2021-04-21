using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f; // speed of bullet
    private Rigidbody bulletRigidbody; // Rigidbody component for bullets

    // Start is called before the first frame update
    void Start()
    {
        // give Rigidbody component to bulletRigidbody
        bulletRigidbody = GetComponent<Rigidbody>();

        // Rigidbody speed = forward * speed
        bulletRigidbody.velocity = transform.forward * speed;

        //destroy gameObject in 3 seconds
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if the tag of object is Player
        if(other.tag == "Player")
        {
            // bring PlayerController component
            PlayerController playerController = other.GetComponent<PlayerController>();

            // if success bring playerController
            if(playerController != null)
            {
                // run Death() method from player
                playerController.Dead();
            }
        }
    }
}
