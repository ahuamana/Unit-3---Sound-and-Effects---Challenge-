using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtyParticle;

    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;

    public bool gameOver;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        //change gravity of physics

        Physics.gravity *= gravityModifier;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //Impulse, It's a force mode which applies inmediatly
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtyParticle.Stop();    
            playerAnim.SetTrigger("Jump_trig");

            playerAudio.PlayOneShot(jumpSound, 1.0f); //1.0f Volume from the sound
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisionaste");

        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Collisionaste");
            dirtyParticle.Play();
            isOnGround = true;
        }
        else 
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                //Debug.Log("Game Over");
                gameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);

                
                explosionParticle.Play();
                //Debug.Log("Play particle");
                dirtyParticle.Stop();

                playerAudio.PlayOneShot(crashSound, 1.0f); //1.0f Volume from the sound
            }
        }
    }
}
