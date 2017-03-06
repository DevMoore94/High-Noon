using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class RaycastShoot : MonoBehaviour {

		public int gunDamage = 1;
		private double rate = 0.75;
		public float lastShot = 0.0f;
		public float weaponRange = 1000f;
		public float hitForce = 100f;
		public Transform gunEnd;
		AudioSource gunShotSound;
		private double FireNext;

		void Start () {
			
			gunShotSound = GetComponent<AudioSource> ();

		}
		

		void Update () {


			if (Input.GetMouseButtonDown (0) && Time.time > FireNext) 
			{
				Debug.Log ("NextFire: " + FireNext);
				Debug.Log ("FireRate: " + rate);
								
				FireNext = Time.time + rate;
				StartCoroutine (fire ());

			}
		}

		private IEnumerator fire(){
			
			gunShotSound.Play ();
			RaycastHit hit;
			Ray ray = new Ray (gunEnd.position, transform.forward);

			if (Physics.Raycast (ray, out hit, weaponRange)) {

				if (hit.collider.tag == "Enemy") {
					Debug.Log ("ENEMY SHOT");
					EnemyController.health -= 25;

				}
			}

			Debug.DrawRay (gunEnd.position, transform.forward * weaponRange, Color.green);
			yield return null;
		}
	}
}