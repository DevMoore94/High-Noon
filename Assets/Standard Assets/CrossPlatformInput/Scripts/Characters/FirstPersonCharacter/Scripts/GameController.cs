﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameController : MonoBehaviour {

		public static int currentLevel = 1;
		public static bool cutsceneDone;

		public Text gameStatusText;
		public Text constantLives;
		private static int lives = 3;




		// Use this for initialization
		void Start () {
			

			constantLives.text = "Lives: " + lives;
			cutsceneDone = false;


		}
		
		// Update is called once per frame
		void Update () {

			if (EnemyController.health >= 0 && FirstPersonController.health <= 0) {
				
				StartCoroutine (DisplayGameMessage ());

			}
			else if (EnemyController.health <= 0 && FirstPersonController.health >= 0) {
				currentLevel++;

				selectLevel ();
			} 
			else if (cutsceneDone) {
				currentLevel++;
				selectLevel ();
			}



		}



		void selectLevel()
		{
			Debug.Log ("CurrentLevel: " + currentLevel);
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
               //     SceneManager.LoadScene();
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
				if (currentLevel == 7) 
				{
					UnityEngine.Application.LoadLevel (7); 
				}
				if (currentLevel == 8) 
				{
					UnityEngine.Application.LoadLevel (8); 
				}
				if (currentLevel == 9) 
				{
					UnityEngine.Application.LoadLevel (9); 
				}
				if (currentLevel == 10) 
				{
					UnityEngine.Application.LoadLevel (10); 
				}
				if (currentLevel == 11) 
				{
					UnityEngine.Application.LoadLevel (11); 
				}
				if (currentLevel == 12) 
				{
					UnityEngine.Application.LoadLevel (12); 
				}
				if (currentLevel == 13) 
				{
					UnityEngine.Application.LoadLevel (13); 
				}
				if (currentLevel == 14) 
				{
					UnityEngine.Application.LoadLevel (14); 

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