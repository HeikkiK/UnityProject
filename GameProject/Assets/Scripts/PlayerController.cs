using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float ActualSpeed = 0;
	public float RotationSpeed = 5;
	public float GravityScale = 0;
	public float CurrentSpeed = 0;
	private Rigidbody2D rb2d;
	private float acceleration = 0.1f;
	private int maxSpeed = 6;
	private Vector3 lastPosition;
	private GameObject enemy_1;
	public float MovedDistance = 0;

	public GameObject leftBullet, rightBullet;
	Transform firePos;

	//miten päin se alus on?
	bool facingRight;

	void Start()
	{
		lastPosition = transform.position;
		rb2d = GetComponent<Rigidbody2D> ();
		enemy_1 = GameObject.Find("Enemy_1");

		firePos = transform.FindChild ("firePos");

	}

	void Update()
	{
		if (enemy_1 == null) 
		{
			enemy_1 = Instantiate(Resources.Load("Prefabs/Enemy_1", typeof(GameObject)) as GameObject);
			//			enemy_1.transform.position = new Vector3(5.6f, 1.9f, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Fire ();
		}
	}

	void FixedUpdate() 
	{
		MovedDistance += Vector3.Distance (transform.position, lastPosition);
		PlayerMovement ();
	}

	private void PlayerMovement()
	{
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			if (CurrentSpeed < maxSpeed) {
				CurrentSpeed += acceleration;
			}
		}
		else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			if (CurrentSpeed > 0) {
				CurrentSpeed -= acceleration;
			}
		}
		else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			transform.Rotate(Vector3.forward * RotationSpeed);
		}
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			transform.Rotate(-Vector3.forward * RotationSpeed);
		}

		transform.position += transform.up * CurrentSpeed * Time.deltaTime;

		// Only calculates actual airplane speed
		ActualSpeed = CommonFunctions.Round(((transform.position - lastPosition).magnitude / Time.deltaTime), 2);
		lastPosition = transform.position;

		//This needs to be changed 
		if (CurrentSpeed < 3 && rb2d.gravityScale <= 0.3f) 
		{
			rb2d.gravityScale += 0.1f * Time.deltaTime;
		} 
		else if (CurrentSpeed > 0 && rb2d.gravityScale >= 0)
		{
			rb2d.gravityScale -= 0.1f * Time.deltaTime;
		}

		GravityScale = rb2d.gravityScale; // only to see gravityscale in UI
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (ActualSpeed > 6.0) 
		{
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene ("Main");
		//muutos
	}

	void Fire()
	{
		//Ongelma on se, että jos alus menee oikealle ja ampuu, niin alus liikkuu vasemmalle
		if(facingRight)
			Instantiate (rightBullet, firePos.position, Quaternion.identity);
		if(!facingRight)
			Instantiate (leftBullet, firePos.position, Quaternion.identity);
			
	}
}
