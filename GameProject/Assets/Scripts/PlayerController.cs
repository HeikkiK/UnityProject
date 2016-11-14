using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float ActualSpeed = 0;
	public float SpeedSetValue = 0;

	private Rigidbody2D rb2d;
	private float maxAcceleration = 3f;
	private int maxSpeed = 100;
	private int rotateSpeed = 5;
	private Vector3 lastPosition;
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
			if (SpeedSetValue < maxSpeed) {
				SpeedSetValue += maxAcceleration * Time.deltaTime;
			}
		}
		else if (Input.GetKey("left") || Input.GetKey("a")) {
			if (SpeedSetValue > 0) {
				SpeedSetValue -= maxAcceleration * Time.deltaTime;
			}
		}
		else if (Input.GetKey("up") || Input.GetKey("w")) {
			transform.Rotate(Vector3.forward * rotateSpeed);
		}
		else if (Input.GetKey("down") || Input.GetKey("s")) {
			transform.Rotate(-Vector3.forward * rotateSpeed);
		}

		rb2d.AddForce (transform.up * SpeedSetValue);
		ActualSpeed = CommonFunctions.Round(((transform.position - lastPosition).magnitude / Time.deltaTime),2);
		lastPosition = transform.position;

//		var turnAmount = Input.GetAxis("Vertical")*turnSpeed;
//
//		transform.Rotate(0,turnAmount,0);
//
//		rb2d.AddRelativeForce(new Vector2(-forwardMoveAmount,0));
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
	}
}
//toinen kommentt
