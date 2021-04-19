using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // bullet prefab
    public float spawnRateMin = 0.5f; // minimum spawn rate
    public float spawnRateMax = 3f; // maximum spawn rate

    private Transform target; // target to shoot bullets
    private float spawnRate; // overal spawn rate
    private float timeAfterSpawn; // time after recent spawn of bullet

    // Start is called before the first frame update
    void Start()
    {
        // reset the stored spawn time to 0
        timeAfterSpawn = 0f;
        // create random spawn rate between min and max spawn rate
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // find object with PlayerController
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // update timeAfterSpawn
        timeAfterSpawn += Time.deltaTime;

        // if timeAfterSpawn was larger than the randomized spawn rate
        if (timeAfterSpawn >= spawnRate)
        {
            // reset timeAfterSpawn
            timeAfterSpawn = 0f;

            // make bulletPrefab copy
            // use transform.position and transform.rotation to create it
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // make the bullets face the target
            bullet.transform.LookAt(target);
            // create new randomized spawn rate using spawnRateMin and spawnRateMax variables
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
