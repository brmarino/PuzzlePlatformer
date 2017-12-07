using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	         //Store a reference to the UI Text component which will display the 'You win' message.
	              //Integer to store the number of pickups collected so far.


	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode throwBall;
	public Canvas canvas;

	private Rigidbody2D theRB;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public bool isGrounded;

	private Animator anim;

	public GameObject snowBall;
	public Transform throwPoint;

	public AudioSource throwSound;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//Initialze winText to a blank string since we haven't won yet at beginning.

		//Call our SetCountText function which will update the text with the current value for count.
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if(Input.GetKey(left))
		{
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
		} else if(Input.GetKey(right))
		{
			theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
		} else {
			theRB.velocity = new Vector2(0, theRB.velocity.y);
		}

		if(Input.GetKeyDown(jump) && isGrounded)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}

		if(Input.GetKeyDown(throwBall))
		{
			GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
			ballClone.transform.localScale = transform.localScale;
			anim.SetTrigger("Throw");

			throwSound.Play();
		}

		if(theRB.velocity.x <0)
		{
			transform.localScale = new Vector3(-1,1,1);
		} else if(theRB.velocity.x > 0)
		{
			transform.localScale = new Vector3(1,1,1);
		}

		anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
		anim.SetBool("Grounded", isGrounded);
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("PickUp"))

			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

		//Add one to the current value of our count variable.
		GameManager.count += 1;
		FindObjectOfType<GameManager> ().SetCountText ();
		//Update the currently displayed count by calling the SetCountText function.
	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
}