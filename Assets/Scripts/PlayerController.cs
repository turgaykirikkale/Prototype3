using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRby;
    public float gravityModifier;
    public float jumpForce = 5;
    public bool isGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explotionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound, crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerRby = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            playerRby.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");

            explotionParticle.Play();
        }

    }
}
