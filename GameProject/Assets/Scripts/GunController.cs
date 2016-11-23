using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//Destroys enemy.  
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Ground_collider" || other.gameObject.name == "Airport" || other.gameObject.name == "Enemy_Airport" || other.gameObject.name == "Player") 
		{
			var explosion = Resources.Load ("Prefabs/Explosion_2", typeof(GameObject)) as GameObject;
			Instantiate(explosion, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}
}
