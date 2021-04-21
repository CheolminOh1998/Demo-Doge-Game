using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        //find Rigidbody component and give it to playerRigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // reads the player input of x and z axis
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // calculate the exact speed by multiplying to the direction inputed
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 speed is created as (xSpeed, 0, zSpeed)
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        // input newVelocity to Rigidbody
        playerRigidbody.velocity = newVelocity;
    }

    public void Dead()
    {
        // Player Object is deactivated
        gameObject.SetActive(false);

        // Bring GameManger type object
        GameManager gameManager = FindObjectOfType<GameManager>();
        // start the EndGame() inside the gameManger object
        gameManager.EndGame();
    }
}
