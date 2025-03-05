using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;

    WaveConfigSO currentWave;
    void Start()
    {
       StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

   // Coroutine added 
    IEnumerator SpawnEnemyWaves ()
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for(int i = 0 ; i< currentWave.GetEnemyCount(); i++)
        {
            // here the 4th parameter passed is the transform of the object itself 'i.e. EnemySpawner' ,it is used here to make the hierachy 
             //less messy as this will instantiate all the new enemy clones into the EnemySpwaner object under the heirarchy.
            Instantiate(currentWave.GetEnemyPrefab(i), 
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWaves);

        }
        
        

    }
}
