using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace UnityStandardAssets.Characters.FirstPerson
{
	public class EnemyController : MonoBehaviour {

		private float speed;
		public static float health = 100f;

		GameObject[] covers;
		GameObject player;
		Transform target;
		NavMeshAgent agent;
		public static bool underFire;
		GameObject ClosestCover;

		double targetTimer = 0;

		// Use this for initialization
		void Start () {
			covers = GameObject.FindGameObjectsWithTag ("cover");
			player = GameObject.FindGameObjectWithTag("Player");
			agent = GetComponent<NavMeshAgent>();
			target = player.transform;
			underFire = false;
			speed = 2.0f;
		}
		
		// Update is called once per frame
		void Update () {
			enemyAi ();

			Debug.Log (underFire.ToString());

		}


		void enemyAi()
		{


			
			if (underFire) 
			{

				findClosestCover ();
				chooseClosestTarget ();
				agent.SetDestination(target.position);

				agent.speed = speed;


			} 
			else
			{
				target = player.transform;
				agent.SetDestination (target.position);
			}

			if (health <= 0) {
				this.gameObject.SetActive (false);
			}


			Debug.Log ("Enemy health: " + health);

		}



		void findClosestCover()
		{
			float distance = 999;
			GameObject closest = null;

			foreach(GameObject obj in covers)
			{
				
				float currentDistance = Vector3.Distance (obj.transform.position, this.transform.position);

				
				if (currentDistance < distance)
				{
					
					distance = currentDistance;
					closest = obj;
				}
			}

			target = closest.transform;
			ClosestCover = closest;
		}

		void chooseClosestTarget()
		{
			float enemyToPos1 = Vector3.Distance (this.transform.position, target.position);
			float enemyToPos2 = Vector3.Distance (this.transform.position, player.transform.position);

			if (enemyToPos1 > enemyToPos2) {
				target = player.transform;
			} 
		}
	

		
	}
		
}