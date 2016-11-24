﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour 
{
	List<string> bombExplosion = null;
	List<string> bulletExplosion = null;

	List<string> bombDestroyItself = null;
	List<string> bulletDestroyItself = null;

	List<string> bombDestroyOther = null;
	List<string> bulletDestroyOther = null;

	// Use this for initialization
	void Start () 
	{
		bombExplosion = new List<string>() { "Enemy_1(Clone)", "Ground_collider", "Airport", "Enemy_Airport", "Player" };
		bulletExplosion = new List<string>() { "Enemy_1(Clone)" };

		bombDestroyItself = new List<string> (bombExplosion);
		bulletDestroyItself = new List<string> (bombExplosion);

		bombDestroyOther = new List<string> (bulletExplosion);
		bulletDestroyOther = new List<string> (bulletExplosion);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.name == "Bullet(Clone)") {
			transform.position += transform.up * 10 * Time.deltaTime;
		}
	}

	//Destroys enemy.  
	void OnCollisionEnter2D(Collision2D other)
	{
		bool allowExplosion = false;
		bool allowDestroyItself = false;
		bool allowDestoyOther = false;

		if (this.name == "Bullet(Clone)") 
		{
			allowExplosion = bulletExplosion.Contains(other.gameObject.name);
			allowDestroyItself = bulletDestroyItself.Contains(other.gameObject.name);
			allowDestoyOther = bulletDestroyOther.Contains(other.gameObject.name);
		}
		else if (this.name == "MegaBomb(Clone)") 
		{
			allowExplosion = bombExplosion.Contains(other.gameObject.name);
			allowDestroyItself = bombDestroyItself.Contains(other.gameObject.name);
			allowDestoyOther = bombDestroyOther.Contains(other.gameObject.name);
		}

		if (allowExplosion) 
		{
			var explosion = Resources.Load ("Prefabs/Explosion_2", typeof(GameObject)) as GameObject;
			Instantiate (explosion, transform.position, transform.rotation);
		}
			
		if (allowDestroyItself) 
		{
			Destroy (gameObject);
		}

		if (allowDestoyOther) 
		{
			Destroy (other.gameObject);
		}
	}
}
