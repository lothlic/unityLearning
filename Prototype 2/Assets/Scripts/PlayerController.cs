using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 20.0f;
    private float xRange = 10.0f;
    public GameObject Ballets;
    public int score = 0;
    public int life = 3;
    //private int T = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("剩余生命：3   当前分数：0");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //发射弹药
            Instantiate(Ballets, transform.position, Ballets.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog") && life >= 0)
        {
            Destroy(other.gameObject);
            life -= 1;
            if (life == 0) Debug.Log("GameOver!");
            else Debug.Log("剩余生命: " + life);
        }
    }
}
