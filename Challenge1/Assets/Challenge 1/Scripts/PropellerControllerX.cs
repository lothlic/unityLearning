using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerControllerX : MonoBehaviour
{
    private float turnSpeed = 720;  //设定螺旋桨转速
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime*turnSpeed);
    }
}
