using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D bunnyRigidBody;
    private Animator bunnyAnimator;
    private Collider2D bunnyCollider;

    private int jumpsRemaining = 2;
    private float bunnyHurtTime = -1;
    private float startingTime;

    public float jumpForce = 100f;
    public AudioSource jumpSfx1;
    public AudioSource jumpSfx2;
    public AudioSource gameOverSfx;
    public Text scoreTxt;

	// Use this for initialization
	void Start ()
    {
        this.bunnyRigidBody = GetComponent<Rigidbody2D>();
        this.bunnyAnimator = GetComponent<Animator>();
        this.bunnyCollider = GetComponent<Collider2D>();

        startingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bunnyHurtTime == -1)
        {
            if (Input.GetButtonUp("Jump") && jumpsRemaining > 0)
            {
                if (jumpsRemaining == 1)
                {
                    bunnyRigidBody.velocity = Vector2.zero;
                    jumpSfx2.Play();
                }
                else
                {
                    jumpSfx1.Play();
                }

                jumpsRemaining--;
                bunnyRigidBody.AddForce(transform.up * jumpForce);
            }

            bunnyAnimator.SetFloat("vVelocity", bunnyRigidBody.velocity.y);
            scoreTxt.text = (Time.time - startingTime).ToString("0.0");
        }
        else
        {
            if(Time.time > bunnyHurtTime + 2)   // after 2 seconds of hit
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsRemaining = 2;
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            bunnyHurtTime = Time.time;
            
            bunnyAnimator.SetBool("bunnyHit", true);

            bunnyCollider.enabled = false;
            bunnyRigidBody.velocity = Vector2.zero;
            bunnyRigidBody.AddForce(transform.up * jumpForce);

            disableObstacles();

            gameOverSfx.Play();
        }
    }

    private void disableObstacles()
    {
        foreach(PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
        {
            spawner.enabled = false;
        }
        foreach(MoveLeft moveLeft in FindObjectsOfType<MoveLeft>())
        {
            moveLeft.enabled = false;
        }
    }
}
