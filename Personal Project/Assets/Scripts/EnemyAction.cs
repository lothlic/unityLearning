using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;
    public float trackSpeed = 8.0f;
    private int modeNum = 0;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        setEnemyMode();
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(modeNum == 1)
        {
            enemyRb.AddForce((player.transform.position - transform.position).normalized * trackSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void setEnemyMode()
    {
        //提供三种模式敌人
        //1.自机狙
        //2.追踪弹
        //3.随机弹
        //
        Rigidbody enemyRb = GetComponent<Rigidbody>();
        int index = Random.Range(0, 2);
        //index = 1;
        switch (index)
        {
            case 0:
                enemyRb.AddForce((player.transform.position - transform.position).normalized * speed, ForceMode.Impulse);
                break;
            case 1:
                modeNum = 1;
                break;
            default:
                break;
        }
    }
}
