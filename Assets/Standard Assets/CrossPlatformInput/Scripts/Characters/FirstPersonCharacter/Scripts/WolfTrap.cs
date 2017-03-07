using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class WolfTrap : MonoBehaviour {

		private int trapDamage;

		// Use this for initialization
		void Start () {
			this.trapDamage = 10;
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
			{
				EnemyController.health -= trapDamage;

			}
		}
	}
}