using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector2 velocity;
	private GameObject player;
	public float SmoothTimeY;
	public float SmoothTimeX;
	private bool Bounds;
	private Vector3 MinCameraPos;
	private Vector3 MaxCameraPos;

	// Use this for initialization
	void Start () {
		MinCameraPos = new Vector3 (-3f, 0f, -10f);
		MaxCameraPos = new Vector3 (10.5f, 0f, -10f);
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, SmoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, SmoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, MinCameraPos.x, MaxCameraPos.x),
			Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y),
			Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z));
	}
}
