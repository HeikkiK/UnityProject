using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Update () 
	{
		transform.position += transform.right * 10 * Time.deltaTime;
	}
}