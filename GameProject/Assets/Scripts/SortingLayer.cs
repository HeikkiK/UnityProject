using UnityEngine;
using System.Collections;

public class SortingLayer : MonoBehaviour {

	public string SortingLayerName = "UI";
	public int SortingOrder = 0;

	void Start ()
	{
		GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
		GetComponent<TextMesh> ().text = "Scores";
	}
}
