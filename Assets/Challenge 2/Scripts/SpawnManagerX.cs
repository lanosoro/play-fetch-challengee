using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnRange = 20;
    private float spawnPosY = 30;
    private float minTime = 2.0f;
    private float maxTime = 5.0f;
    public float spawnTimeInterval;
    public float timer;
    private float startDelay =3.0f;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }
    void update () {
        timer += Time.deltaTime;
        if (timer > spawnTimeInterval)
        {
            SpawnRandomBall();
            spawnTimeInterval = Random.Range(minTime, maxTime);
            timer = 0;
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnRange, -spawnRange), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos,
        ballPrefabs[ballIndex].transform.rotation) ;
        
    }

}
