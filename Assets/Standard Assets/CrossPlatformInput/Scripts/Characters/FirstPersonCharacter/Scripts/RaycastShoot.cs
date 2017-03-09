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

		private Rigidbody bulletRigidbody;
		public GameObject bullet;
		public GameObject crosshair;



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

			GameObject bulletClone = Instantiate (bullet, gunEnd.transform.position, gunEnd.transform.rotation);
			Rigidbody bulletCloneRigidbody =  bulletClone.GetComponent<Rigidbody> ();

			RaycastHit hit;

			//Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));
			Vector3 rayOrigin = gunEnd.position;

			if (Physics.Raycast (rayOrigin,fpsCamera.transform.forward, out hit, weaponRange)) {

				if (hit.collider.tag == "Enemy") {
					EnemyController.health -= 50;

				}
			}


			bulletCloneRigidbody.velocity = fpsCamera.transform.forward * 20;

			Debug.DrawRay (gunEnd.position, fpsCamera.transform.forward * weaponRange, Color.green);
			yield return null;
		}
	}
}