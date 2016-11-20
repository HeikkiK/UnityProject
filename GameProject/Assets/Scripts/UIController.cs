using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	private string sortingLayerName = "UI";
	private int sortingOrder = 0;
	private PlayerController Player;
	private TextMesh TextObject;

	void Start ()
	{
		Player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		GetComponent<MeshRenderer> ().sortingLayerName = sortingLayerName;
		GetComponent<MeshRenderer> ().sortingOrder = sortingOrder;
		TextObject = GetComponent<TextMesh> ();
	}

	void Update()
	{
		SetUIComponentPositions ();

		UpdateUIComponentValue ();

	}

	void UpdateUIComponentValue()
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

	void SetUIComponentPositions()
	{
		switch (name) 
		{
		case "PlayerFuel":
			{
				var xValue = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)).x;
				transform.position = new Vector3 (xValue, -4, 0);
				break;
			}
		case "PlayerScores":
			{
				var xValue = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
				transform.position = new Vector3 (xValue, 5, 0);
				break;
			}
		default:
			break;
		}
	}
}
