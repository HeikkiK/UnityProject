using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	public float RotationSpeed = 5;
	public bool IsEnemyDisabled = false;

	private GameObject player;
	private float currentSpeed = 3;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.Find("Player");
	}

	void OnBecameInvisible() 
	{
		DestroyObject (gameObject);
	}
	// Update is called once per frame
	void Update () 
	{
//		transform.position += transform.up * currentSpeed * Time.deltaTime;
	}

	void LateUpdate()
	{
		if (!IsEnemyDisabled) 
		{
			FollowPlayer ();
		}
	}

	public void FollowPlayer()
	{
		transform.LookAt(player.transform.position);
		transform.Rotate(new Vector3 (0, 90, 90));

		Vector3 targetPoint = player.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, targetPoint, 3 * Time.deltaTime);
	}
}
