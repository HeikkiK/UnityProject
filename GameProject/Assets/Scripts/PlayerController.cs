using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public static float ActualSpeed = 0;
	public float RotationSpeed = 5;
	public float CurrentSpeed = 0;
	public float MovedDistance = 0;
	public static float FullTankSize = 1500;
	public static float RemainingFuel = 0;
	public float FuelConsumtion = 0;
	public float RemainInProcent = 0;

	private Rigidbody2D rb2d;
	private float acceleration = 0.1f;
	private int maxSpeed = 6;
	private Vector3 lastPosition;
	private GameObject enemy_1;
	private bool isOutOfFuel = false;
	//public float fireRate = 0;
	private GameObject explosion;
	private GameObject bullet, megaBomb;

	void Start()
	{
		megaBomb = Resources.Load ("Prefabs/MegaBomb", typeof(GameObject)) as GameObject;
		bullet = Resources.Load ("Prefabs/Bullet", typeof(GameObject)) as GameObject;
		FuelConsumtion = 15f;
		lastPosition = transform.position;
		rb2d = GetComponent<Rigidbody2D> ();
		RemainingFuel = FullTankSize;
	}

	void Update()
	{
		PlayerShooting ();
	}
		
	void FixedUpdate() 
	{
		isOutOfFuel = CalculateFuelConsumption ();
		PlayerMovement ();
	}		
		
	private void PlayerShooting()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Instantiate(bullet, transform.position, transform.rotation);				
		}
		else if (Input.GetKeyDown (KeyCode.E)) 
		{
			Instantiate(megaBomb, transform.position, transform.rotation);
		}
	}

	private bool CalculateFuelConsumption()
	{
		MovedDistance += Vector3.Distance (transform.position, lastPosition);
		if (RemainingFuel > 0) {
			RemainingFuel -= FuelConsumtion * Vector3.Distance (transform.position, lastPosition);
			RemainInProcent = Mathf.Max((100 / FullTankSize) * RemainingFuel, 0);
		} else {
			return true;
		}
		return false;
	}

	private void PlayerMovement()
	{
		if (isOutOfFuel) {
			CurrentSpeed = 0;
			GameObject.Find("Smoke").GetComponent<ParticleSystem>().Stop ();
		} 
		else 
		{
			GameObject.Find ("Smoke").GetComponent<ParticleSystem> ().Play ();
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
			{
				if (CurrentSpeed < maxSpeed) {
					CurrentSpeed += acceleration;
				}
			}
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			if (CurrentSpeed > 0) {
				CurrentSpeed -= acceleration;
			} else {
				CurrentSpeed = 0;
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
		ActualSpeed = rb2d.velocity.magnitude;

		//This needs to be changed 
		if (CurrentSpeed < 3 && rb2d.gravityScale <= 0.3f) 
		{
			rb2d.gravityScale += 0.1f * Time.deltaTime;
		} 
		else if (CurrentSpeed > 0 && rb2d.gravityScale >= 0)
		{
			rb2d.gravityScale -= 0.1f * Time.deltaTime;
		}
		lastPosition = transform.position;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (ActualSpeed > 6.0 || other.gameObject.name == "Ground_collider") 
		{
			Die();
		}
	}

	void Die()
	{
		explosion = Resources.Load ("Prefabs/Explosion_2", typeof(GameObject)) as GameObject;
		Instantiate(explosion, transform.position, transform.rotation);

		if (gameObject != null) {
			Destroy (gameObject);
		}
//		SceneManager.LoadScene ("Main");
	}
}
