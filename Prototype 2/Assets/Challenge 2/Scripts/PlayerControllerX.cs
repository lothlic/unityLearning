using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    //private GameObject dog;
    // Update is called once per frame
    private float time=-1.0f;
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKey(KeyCode.Space)&&(time+0.5f)<Time.time)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            time = Time.time;
        }
    }
}
