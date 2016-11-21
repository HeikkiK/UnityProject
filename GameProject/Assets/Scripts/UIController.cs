using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	private string sortingLayerName = "UI";
	private int sortingOrder = 0;
	private PlayerController player;
	private TextMesh TextObject;

	void Start ()
	{
		GetComponent<MeshRenderer> ().sortingLayerName = sortingLayerName;
		GetComponent<MeshRenderer> ().sortingOrder = sortingOrder;
		TextObject = GetComponent<TextMesh> ();
	}

	void LateUpdate()
	{
		if (player == null) {
			player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		}
		else {
			SetUIComponentPositions ();

			UpdateUIComponentValue ();
		}
	}

	void UpdateUIComponentValue()
	{
		switch (name) 
		{
		case "PlayerFuel":
			{
				TextObject.text = ((int)player.RemainInProcent).ToString() + "%";
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
