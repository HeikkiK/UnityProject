using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool DisableEnemies = false;
	public static GameManager instance = null;

	private GameObject enemy_1;
	private GameObject player;

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
		if (DisableEnemies) {
			Destroy (enemy_1);
		}

		if (enemy_1 == null && !DisableEnemies) 
		{
			enemy_1 = Instantiate(Resources.Load("Prefabs/Enemy_1", typeof(GameObject)) as GameObject);
		}

		if (player == null) 
		{
			player = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)) as GameObject);
		}
	}
}
