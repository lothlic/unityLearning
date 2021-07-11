using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;   //敌人数量
    public GameObject powerupPrefab;
    public int waveNumber = 1;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        } 
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int eneimesToSpawn)
    {
        for (int i=0;i< eneimesToSpawn; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
