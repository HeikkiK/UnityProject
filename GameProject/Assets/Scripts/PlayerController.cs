using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float CurrentSpeed = 0;
	private Rigidbody2D rb2d;
	private float maxAcceleration = 3f;
	private int maxSpeed = 100;
	private int rotateSpeed = 5;
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update() 
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
			transform.Rotate(Vector3.forward * rotateSpeed);
		}
		else if (Input.GetKey("down") || Input.GetKey("s")) {
			transform.Rotate(-Vector3.forward * rotateSpeed);
		}

		rb2d.AddForce (transform.up * CurrentSpeed);


	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (CurrentSpeed > 7.0) 
		{
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene ("Main");
	}
}
