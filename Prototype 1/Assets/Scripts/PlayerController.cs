using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public Camera cameraFollower;
    public Camera cameraFollower2;
    //public List<Camera> cameras;
    CurrentStatus cuSta = CurrentStatus.第三人称;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cameraFollower2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndTurn();
        SwitchCamera();
    }
    //移动
    private void MoveAndTurn()
    {
        if (gameObject.CompareTag("Player"))
        {
            /*
            //wasd输入
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            //汽车前后移动
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
            */
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                //playerRb.AddForce(Vector3.left * speed, ForceMode.Impulse);
                transform.Rotate(-Vector3.up * Time.deltaTime * turnSpeed);
            }
            if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            }
        }
        if (gameObject.CompareTag("Player2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up * Time.deltaTime * turnSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            }
        }
    }

    //转弯
    
    private void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("视角切换");
            if (cuSta == CurrentStatus.第三人称)
            {
                cuSta = CurrentStatus.第一人称;
                //transform.localPosition = offset2;
                cameraFollower.enabled = !cameraFollower.enabled;
                cameraFollower2.enabled = !cameraFollower2.enabled;
            }
            else
            {
                cuSta = CurrentStatus.第三人称;
                //transform.localPosition = offset;
                cameraFollower.enabled = !cameraFollower.enabled;
                cameraFollower2.enabled = !cameraFollower2.enabled;
            }
        }
    }
    
}
