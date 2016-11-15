using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float ActualSpeed = 0;
	public float CurrentSpeed = 0;
	public float RotationSpeed = 5;

	private Rigidbody2D rb2d;
	private float maxAcceleration = 0.1f;
	private int maxSpeed = 50;
	private Vector3 lastPosition;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() 
	{
		PlayerMovement ();
	}

	private void PlayerMovement()
	{
		if (Input.GetKey("right") || Input.GetKey("d")) 
		{
			if (CurrentSpeed < maxSpeed) {
				CurrentSpeed += maxAcceleration * Time.deltaTime;
			}
		}
		else if (Input.GetKey("left") || Input.GetKey("a")) {
			if (CurrentSpeed > 0) {
				CurrentSpeed -= maxAcceleration * Time.deltaTime;
			}
		}
		else if (Input.GetKey("up") || Input.GetKey("w")) {
			transform.Rotate(Vector3.forward * RotationSpeed);
		}
		else if (Input.GetKey("down") || Input.GetKey("s")) {
			transform.Rotate(-Vector3.forward * RotationSpeed);
		}

		transform.position += transform.up * CurrentSpeed;
//		rb2d.AddForce (transform.up * CurrentSpeed);

		// Only calculates actual airplane speed
		ActualSpeed = CommonFunctions.Round(((transform.position - lastPosition).magnitude / Time.deltaTime),2);
		lastPosition = transform.position;

		if (ActualSpeed < 3) {
			rb2d.gravityScale = 0.2f;
		} else {
			rb2d.gravityScale = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (ActualSpeed > 7.0) 
		{
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene ("Main");
		//Hep
	}
}
