 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameController : MonoBehaviour {

		private int currentLevel;

		public Text gameStatusText;
		public Text constantLives;
		private static int lives = 3;



		// Use this for initialization
		void Start () {
			currentLevel = 1;

			constantLives.text = "Lives: " + lives;


		}
		
		// Update is called once per frame
		void Update () {

			if (EnemyController.health >= 0 && FirstPersonController.health <= 0) 
			{
				
				StartCoroutine (DisplayGameMessage());

			}
			else if (EnemyController.health <= 0 && FirstPersonController.health >= 0) 
			{
				currentLevel++;

				selectLevel ();
			}
		}



		void selectLevel()
		{
			if (lives == 0) 
			{
				UnityEngine.Application.LoadLevel (0); 
				lives = 3;
			} 
			else 
			{
				
				if (currentLevel == 1) 
				{
					UnityEngine.Application.LoadLevel (1); 
				}
				if (currentLevel == 2) 
				{
					UnityEngine.Application.LoadLevel (2); 
				}
				if (currentLevel == 3) 
				{
					UnityEngine.Application.LoadLevel (3); 
				}
				if (currentLevel == 4)
				{
					UnityEngine.Application.LoadLevel (4); 
				}
				if (currentLevel == 5)
				{
					UnityEngine.Application.LoadLevel (5); 
				}
				if (currentLevel == 6) 
				{
					UnityEngine.Application.LoadLevel (6); 
				}
			}

			resetGameValues ();
		}

		void resetGameValues()
		{
			EnemyController.health = 100;
			FirstPersonController.health = 100;

		}

		IEnumerator DisplayGameMessage()
		{
			
			gameStatusText.text = "YOU DIED!";
			constantLives.text = "Lives: " + (lives-1);
			yield return new WaitForSeconds(3);

			lives = lives - 1;

			selectLevel ();
		}
	}
}