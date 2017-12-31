using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D bunnyRigidBody;
    private Animator bunnyAnimator;

    public float jumpForce = 100f;

	// Use this for initialization
	void Start () {
        this.bunnyRigidBody = GetComponent<Rigidbody2D>();
        this.bunnyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonUp("Jump"))
        {
            bunnyRigidBody.AddForce(transform.up * jumpForce);
        }
        
        bunnyAnimator.SetFloat("vVelocity", Mathf.Abs(bunnyRigidBody.velocity.y));

    }
}
