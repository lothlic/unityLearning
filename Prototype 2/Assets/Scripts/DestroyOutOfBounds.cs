using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topzBound = 30;
    private float lowerzBound = -10;
    private float topxBound = 20;
    private float lowerxBound = -20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topzBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerzBound)
        {
            Destroy(gameObject);
            //Debug.Log("GameOver!");
            LifeManage();
        }
        if(transform.position.x > topxBound || transform.position.x < lowerxBound)
        {
            Destroy(gameObject);
            LifeManage();
        }
    }
    private void LifeManage()
    {
        int lifeCur = FindObjectOfType<PlayerController>().life -= 1;
        if (lifeCur == 0) Debug.Log("GameOver!");
        else if (lifeCur > 0) Debug.Log("剩余生命: " + lifeCur);
    }
}
