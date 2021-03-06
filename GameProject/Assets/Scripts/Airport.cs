using UnityEngine;
using System.Collections;

public class Airport : MonoBehaviour {
	bool Refuel = false;
	public float RefuelingSpeed = 10;
	 
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Refuel && PlayerController.ActualSpeed == 0 && PlayerController.RemainingFuel < PlayerController.FullTankSize) {
			PlayerController.RemainingFuel += RefuelingSpeed + Time.deltaTime;  //if player is at airport give plane tank of fuel.
		}
	}
	void OnCollisionEnter2D(Collision2D other) //player is at the airport
	{
		if (other.gameObject.name == "Player(Clone)")
		{
			Refuel = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll) //Player left the airport
	{
		if (coll.gameObject.name == "Player(Clone)")
		{
			Refuel = false;
		}

	}
}
