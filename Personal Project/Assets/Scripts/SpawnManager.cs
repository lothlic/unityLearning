using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public int enemyCount = 4;
    public float playTime = 0;
    public bool isGameActive = true;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemies",0,1);
        UpdateScore(0);
        StartCoroutine(ScoreCreasingWithTime());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isGameActive)
        {
            playTime += Time.deltaTime;
            CreateEnemies();
        }*/

    }

    void CreateEnemies()
    {
        for(int i=0; i < enemyCount; i++)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 0, Random.Range(8f, 10f)), enemy.transform.rotation);
        }
    }
    public void UpdateScore(int scoreAdd)
    {
        if (isGameActive)
        {
            score += scoreAdd;
            scoreText.text = "score: " + score;
        }
    }

    IEnumerator ScoreCreasingWithTime()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(1f);
            UpdateScore(5);
        }
    }
    
}
