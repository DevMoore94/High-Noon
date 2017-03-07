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
		public Camera fpsCamera;


		void Start () {
			
			gunShotSound = GetComponent<AudioSource> ();

		}
		

		void Update () {


			if (Input.GetMouseButtonDown (0) && Time.time > FireNext) 
			{
				
				FireNext = Time.time + rate;
				StartCoroutine (fire ());

			}
		}

		private IEnumerator fire(){
			gunShotSound.Play ();
			RaycastHit hit;

			Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));

			if (Physics.Raycast (rayOrigin,fpsCamera.transform.forward, out hit, weaponRange)) {

				if (hit.collider.tag == "Enemy") {
					EnemyController.health -= 50;

				}
			}
				
			Debug.DrawRay (gunEnd.position, transform.forward * weaponRange, Color.green);
			yield return null;
		}
	}
}