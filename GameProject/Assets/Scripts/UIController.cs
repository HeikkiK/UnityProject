using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	private string sortingLayerName = "UI";
	private int sortingOrder = 0;
	private PlayerController Player;
	public TextMesh TextObject;

	void Start ()
	{
		Player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		GetComponent<MeshRenderer> ().sortingLayerName = sortingLayerName;
		GetComponent<MeshRenderer> ().sortingOrder = sortingOrder;
		TextObject = GetComponent<TextMesh> ();
	}

	void Update()
	{
		switch (name) 
		{
		case "PlayerFuel":
			{
				TextObject.text = ((int)Player.RemainInProcent).ToString() + "%";
				break;
			}
		case "PlayerScores":
			{
				TextObject.text = "Scores";
				break;
			}
			default:
				break;
		}
	}
}
