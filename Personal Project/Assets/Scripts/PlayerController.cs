using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    public GameObject ballet;
    private Vector3 balletOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        balletOffset = new Vector3(0,0,0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
     //玩家行动函数
    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        if(transform.position.x>=9.5)
        transform.position= new Vector3(9.5f, transform.position.y, transform.position.z);
        if (transform.position.x <= -9.5)
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        if (transform.position.z >= 9.5)
            transform.position = new Vector3(transform.position.x, transform.position.y, 9.5f);
        if (transform.position.z <= -9.5)
            transform.position = new Vector3(transform.position.x, transform.position.y, -9.5f);
    }

     //玩家射击函数
    private void Shoot()
    {
        Instantiate(ballet, transform.position + balletOffset, Quaternion.Euler(90.0f,0,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<SpawnManager>().isGameActive = false;
            Debug.Log("GameOver!");
        }
    }

}
