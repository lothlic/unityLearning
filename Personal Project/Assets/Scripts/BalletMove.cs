using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalletMove : MonoBehaviour
{
    public float speed = 40.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            //int score = FindObjectOfType<SpawnManager>().score += 5;
            FindObjectOfType<SpawnManager>().UpdateScore(5);
            //scoreText.text = "score: " + FindObjectOfType<SpawnManager>().score;
        }
    }
}
