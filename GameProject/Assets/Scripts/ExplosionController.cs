using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	bool isDestroying = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Destroy explosion gameobject after 5 sec
		if (!isDestroying)
		{
			isDestroying = true;
			Destroy (this.gameObject, 5f);
		}
	}
}
