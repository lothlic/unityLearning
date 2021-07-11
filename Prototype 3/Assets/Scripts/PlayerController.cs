using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;  //物理模型
    public float jumpForce = 10;    //跳跃力度
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;   //人物动画
    public ParticleSystem explosionParticle;  //爆炸粒子特效
    public ParticleSystem dirtyParticle;      //尘埃粒子特效
    public AudioClip jumpSound;    //跳跃音效
    public AudioClip crashSound;    //冲刺音效
    private AudioSource playerAudio; //声音播放器
    //*******进阶修改：二段跳*********//
    private int jumpNum = 0;  //人物跳跃过的次数
    private int jumpUpLimit = 2;    //人物跳跃次数上限
    #region 设计思路：跳跃次数有上限，在达到上限前可以起跳，落地后次数归零
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpNum< jumpUpLimit && !gameOver)  //如果按下空格键而且人物处于地面
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");   //动画触发跳跃
            jumpNum++;
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))    //如果碰上地面，可以再次起跳
        {
            isOnGround = true;
            jumpNum = 0;
            dirtyParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))   //碰上障碍物，游戏结束
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
