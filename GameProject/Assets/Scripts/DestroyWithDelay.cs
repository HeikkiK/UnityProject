using UnityEngine;
using System.Collections;

public class DestroyWithDelay : MonoBehaviour 
{
	public float delay;

	// Use this for initialization
	//This destroy bullets
	void Start () 
	{
		Destroy (gameObject, delay);
	}
	
}
