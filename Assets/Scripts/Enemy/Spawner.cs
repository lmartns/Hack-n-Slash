using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject goblin;
    public float spawnRate;

    private float nestSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nestSpawn)
        {
            nestSpawn = Time.time + spawnRate;

            Instantiate(goblin, transform.position, goblin.transform.rotation);
        }
    }
}
