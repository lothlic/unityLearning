using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int animalIndex;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalHorizontal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }
    //产生竖直方向敌人
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        //生成一个新的动物
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    //产生水平方向敌人
    void SpawnRandomAnimalHorizontal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(0,2)*40 - 20, 0, Random.Range(0f,12.0f));
        animalIndex = Random.Range(0, animalPrefabs.Length);
        //生成一个新的动物
        if(spawnPos.x<0)
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0,90,0));
        else
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 270, 0));
    }
}
