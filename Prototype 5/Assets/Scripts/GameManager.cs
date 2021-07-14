using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;   //得分文本
    public TextMeshProUGUI gameOverText;    //游戏结束文本
    public Button restartButton;  //重启按钮
    public bool isGameActive = true;    //判断游戏是否还在进行
    public GameObject titleScreen;   //标题显示
    private float spawnRate = 1.0f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(SpawnTarget());
        //score = 0;
        //UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count); //随机一个序号
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;   //得分增加
        scoreText.text = "Score: " + score;  //得分显示
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //开始游戏
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
