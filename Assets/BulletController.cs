﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class BulletController : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnCollisionEnter(Collision col)
		{



			if (col.gameObject.tag == "Enemy") 
			{
				EnemyController.health -= 50;
				Debug.Log ("Enemy Health : " + EnemyController.health);

			}

			if (col.gameObject.tag == "Player") 
			{
				FirstPersonController.health -= 50;
				Debug.Log("PLAYER HIT : HEALTH : " + FirstPersonController.health);

			}


			this.gameObject.SetActive (false);


		}
	}
}
