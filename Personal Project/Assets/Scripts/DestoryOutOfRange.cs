using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfRange : MonoBehaviour
{
    private float xRange = 10f;
    private float zRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x) > xRange || Mathf.Abs(transform.position.z) > zRange)
        {
            Destroy(gameObject);
        }
    }
}
