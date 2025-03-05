using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    //Creating refernce to the 'EnemySpawner' script.
    EnemySpawner enemySpawner;
    //removed WaveConfigSO as a serializedfield to directly access the WaveConfig without the room of error like forgetiing and mismatching the wrong 
    // WaveConfig to the wrong Pathfinder script.
    WaveConfigSO waveConfig; 
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    
    void Update()
    {
        FollowPath();
        
    }

    void FollowPath(){
        if(waypointIndex < waypoints.Count){
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition){
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
