using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public float floatForce;
    private float collisionForce = 5;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip collisionSound;

    private bool collisionFlag = true;  //能否与地面碰撞

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 14) {
            transform.position = new Vector3(transform.position.x, 14, transform.position.z);
            playerRb.velocity = new Vector3(0, 0, 0);
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
        Debug.Log(collisionFlag);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = transform.position;  //烟花位置和气球一致
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        
        else if (other.gameObject.CompareTag("Ground") && collisionFlag)
        {
            /*collisionFlag = false;
            Debug.Log("碰撞");*/
            playerRb.AddForce(Vector3.up * collisionForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(collisionSound, 1.0f);
            //StartCoroutine(countCollsionTime());
        }
        
    }
    IEnumerator countCollsionTime()
    {
        yield return new WaitForSeconds(0.5f);
        collisionFlag = true;
    }
}
