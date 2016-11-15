using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	private float currentSpeed = 3;
	private Rigidbody2D rb2d;
	private GameObject enemy_1;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		enemy_1 = gameObject;
	}

	void OnBecameInvisible() {
		DestroyObject (gameObject);
	}
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * currentSpeed * Time.deltaTime;

		if (enemy_1 == null) 
		{
			enemy_1 = GameObject.Find("Enemy_1");
//			enemy_1.transform.position = new Vector3(5.6f, 1.9f, 0);
		}

	}
}
