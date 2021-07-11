using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //方向键输入
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //汽车前后移动
        transform.Translate(Vector3.forward *Time.deltaTime * speed * forwardInput);
        //转弯
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
    }
}
