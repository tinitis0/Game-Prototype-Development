using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;  // starts the wavepoint count at 0

    private Enemy nEnemy;

    void Start()
    {
        nEnemy = GetComponent<Enemy>();
        target = Waypoints.Markers[0];// sets the target for the car/enemy to first waypoint
    }

    void Update() //updates the target towards the next waypoint
    {
        Vector3 dir = target.position - transform.position; // vector 3 finds the coordinates of the waypoint and points the enemy towards it
        transform.Translate(dir.normalized * nEnemy.speed * Time.deltaTime, Space.World); //normalized keeps the speed fixed
        transform.rotation = Quaternion.LookRotation(dir);


        if (Vector3.Distance(transform.position, target.position) <= 0.2f) // detects the waypoint
        {
            GetNextWaypoint(); //finds the next waypoint
        }

        nEnemy.speed = nEnemy.startSpeed;

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.Markers.Length - 1) // checks if the last waypoint is reached
        {
            PathEnd();

            return;
        }

        wavepointIndex++; //next waypoint is the same waypoint +1
        target = Waypoints.Markers[wavepointIndex]; // gets the waypoint and sets it as the target for the car/enemy
    }

    void PathEnd()
    {
        Lives.Hearts--; //takes away 1 heart every time enemy has reached the red building at the end of the path
        WaveSpawner.EnemiesLeft--; // when enemies reach end they call/do same thing as kill method with this
        Destroy(gameObject); // destroys the enemy once the last waypoint is reached
    }
}
