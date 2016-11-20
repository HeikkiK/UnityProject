using UnityEngine;
using System.Collections;

public class Airport : MonoBehaviour {
	bool Refuel = false;

	 
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Refuel && PlayerController.ActualSpeed == 0) PlayerController.RemainingFuel = PlayerController.FullTankSize; //if player is at airport give plane tank of fuel.
	}
	void OnCollisionEnter2D(Collision2D other) //player is at the airport
	{
		if (other.gameObject.name == "Player")
		{
			Refuel = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll) //Player left the airport
	{
		if (coll.gameObject.name == "Player")
		{
			Refuel = false;
		}

	}
}
