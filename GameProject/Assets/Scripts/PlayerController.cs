using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed = 6.0F;
	private Rigidbody rb2d;
	void Start()
	{
		rb2d = GetComponent<Rigidbody> ();
	}

	void Update() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * Speed);
	}
}
