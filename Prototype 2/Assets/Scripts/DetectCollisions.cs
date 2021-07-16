using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            if(player.GetComponent<PlayerController>().life > 0)
            {
                player.GetComponent<PlayerController>().score += 5;
                Debug.Log("当前分数：" + player.GetComponent<PlayerController>().score);
            }
        }
    }
}
