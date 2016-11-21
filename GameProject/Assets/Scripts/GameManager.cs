using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject enemy_1;
	private GameObject player;
	public static GameManager instance = null;
	// Use this for initialization
	void Awake () 
	{
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if (enemy_1 == null) 
		{
			enemy_1 = Instantiate(Resources.Load("Prefabs/Enemy_1", typeof(GameObject)) as GameObject);
		}

		if (player == null) 
		{
			player = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject);
		}
	}
}
