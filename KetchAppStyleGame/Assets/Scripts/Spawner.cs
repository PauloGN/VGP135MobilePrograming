using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] pickups;
    [SerializeField] private float delayObstaclesSpawn = 3.0f;
    [SerializeField] private int spawnPickupEachXobstacles = 7;
    [SerializeField] private float maxForce = 4.0f;
    [SerializeField] private float minForce = 1.0f;

    //References

    private Camera mainCamera;

    //Timers and controllers
    private float obstaclesTimer = 0.0f;
    private int countObstacles = 0;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Obstacles spawn
        obstaclesTimer -= Time.deltaTime;
        if(obstaclesTimer <= 0)
        {
            SpawnObstacles();
            obstaclesTimer += delayObstaclesSpawn;
        }

    }

    private void SpawnObstacles()
    {
        countObstacles++;
        int sideOfScreen = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (sideOfScreen)
        {
            case 0:

                //Left side
                spawnPoint.x = 0.0f;
                spawnPoint.y = Random.value;
                direction = new Vector2(1.0f, Random.Range(-1.0f, 1.0f));

                break;
            case 1:
                //Right side

                spawnPoint.x = 1.0f;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1.0f, Random.Range(-1.0f, 1.0f));

                break;
            case 2:
                //Left Bottom

                spawnPoint.y = 0.0f;
                spawnPoint.x = Random.value;
                direction = new Vector2(Random.Range(-1.0f, 1.0f), 1.0f);

                break;
            case 3:
                //Top side

                spawnPoint.y = 1.0f;
                spawnPoint.x = Random.value;
                direction = new Vector2(Random.Range(-1.0f, 1.0f), -1.0f);

                break;

        }


        Vector3 worldSpawnPoit = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoit.z = 0.0f;

        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Length)];
        Quaternion obstacleRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)) ;

        GameObject obstacleInstance  = Instantiate(selectedObstacle, worldSpawnPoit, obstacleRotation);

        Rigidbody rb = obstacleInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(minForce, maxForce);

        if (countObstacles == spawnPickupEachXobstacles)
        {
            countObstacles = 0;

            SpawnPickUps(worldSpawnPoit, direction);

        }

    }

    private void SpawnPickUps(Vector3 worldSpawnPoit, Vector3 direction)
    {
        
        worldSpawnPoit.z = 0.0f;

        GameObject selectedPickup = pickups[Random.Range(0, pickups.Length)];
        
        GameObject pickupInstance = Instantiate(selectedPickup, worldSpawnPoit, selectedPickup.transform.rotation);

        Rigidbody rb = pickupInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * minForce;
    }

    //Increases the game difficulty
    public void GettingHarder()
    {
        if (delayObstaclesSpawn > 0.5f)
        {

            delayObstaclesSpawn -= 0.5f;

        }

        if(maxForce < 7)
        {
            maxForce++;
        }

    }


}
