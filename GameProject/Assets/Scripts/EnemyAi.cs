using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	public float RotationSpeed = 5;
	public float DistanceToPlayer = 0;

	private float fireDelta = 0.2F;
	private float nextFire = 0.5F;
	private float myTime = 0.0F;
	private GameObject player;
	private float currentSpeed = 3;
	private Rigidbody2D rb2d;
	private GameObject bullet;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		bullet = Resources.Load ("Prefabs/Bullet", typeof(GameObject)) as GameObject;
	}

	void OnBecameInvisible() 
	{
//		DestroyObject (gameObject);
	}
	// Update is called once per frame
	void Update () 
	{
		EnemyShooting ();
	}

	void LateUpdate()
	{
		if (player == null) 
		{
			player = GameObject.Find("Player(Clone)");
		} 

		FollowPlayer ();
	}

	private void EnemyShooting()
	{
		DistanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
		if (DistanceToPlayer < 10)
		{
			myTime = myTime + Time.deltaTime;
			if (myTime > nextFire) {
				nextFire = myTime + fireDelta;
				var shooted = Instantiate (bullet, transform.position, transform.rotation);
				(shooted as GameObject).GetComponent<GunController> ().Shooter = this.name;
				nextFire = nextFire - myTime;
				myTime = 0.0F;
			}
		}
	}

	public void FollowPlayer()
	{
		transform.LookAt(player.transform.position);
		transform.Rotate(new Vector3 (0, 90, 90));

		Vector3 targetPoint = player.transform.position;
		transform.position = Vector3.MoveTowards(transform.position, targetPoint, currentSpeed * Time.deltaTime);
	}
}
