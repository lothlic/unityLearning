using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentStatus
{
    第三人称,
    第一人称,
};
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,5,-7);
    private Vector3 offset2 = new Vector3(0,2.29f,0.96f);
    private Vector3 defaultOffset;
    private float distanceToPlayer = 8.6f;
    
    CurrentStatus cuSta = CurrentStatus.第三人称;
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion originQua = transform.rotation - player.transform.rotation;
        defaultOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        
        //切换视角
        /*
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("空格键按下");
            if(cuSta == CurrentStatus.第三人称)
            {
                cuSta = CurrentStatus.第一人称;
                transform.localPosition = offset2;
            }
            else
            {
                cuSta = CurrentStatus.第三人称;
                transform.localPosition = offset;
            }
        }
        */
    }
    
}
