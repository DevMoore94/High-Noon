using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace UnityStandardAssets.Characters.FirstPerson
{
	public class EnemyController : MonoBehaviour {

		private float speed;
		public static float health = 100f;

		public GameObject player;
		//AI Variables
		GameObject[] covers;

		public static Transform target;
		NavMeshAgent agent;
		public static bool underFire;
		GameObject ClosestCover;

		//animation Logic Variables
		double targetTimer = 0;
		double coverWaitTime = 3;
		Animator animator;

		// Use this for initialization
		void Start () {
			covers = GameObject.FindGameObjectsWithTag ("cover");
			player = GameObject.FindGameObjectWithTag("Player");
			animator = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();
			target = player.transform;
			underFire = false;
			speed = 2.0f;
			animator.SetBool ("isMoving", true);
		}
		
		// Update is called once per frame
		void Update () {
			enemyAi ();

		}


		void enemyAi()
		{
	
			if (underFire) 
			{

				findClosestCover ();
				chooseClosestTarget ();
				agent.SetDestination (target.position);
				agent.speed = speed;

				float currentDistance = Vector3.Distance (target.position, this.transform.position);

				if (target.tag == "cover" && currentDistance < 1) 
				{
					animator.SetBool ("isMoving", false);
					targetTimer = targetTimer + 1 * Time.deltaTime;

					if (targetTimer >= coverWaitTime)
					{
						targetTimer = 0;
						underFire = false;

					}
				}

			} 
			else
			{
				target = player.transform;
				agent.SetDestination (target.position);
					
			}

			if (health <= 0) {
				this.gameObject.SetActive (false);
			}

			if (target.tag == "Player") 
			{
				animator.SetBool ("isMoving", true);

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