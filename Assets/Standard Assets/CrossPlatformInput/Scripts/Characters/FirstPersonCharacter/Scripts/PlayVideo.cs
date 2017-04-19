using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
[RequireComponent (typeof(AudioSource))]


	public class PlayVideo : MonoBehaviour {

		public MovieTexture movie;
		private AudioSource audio;
		private float timeSinceStart;

		// Use this for initialization
		void Start () {
			timeSinceStart = 0;
			GetComponent<RawImage> ().texture = movie as MovieTexture;
			audio = GetComponent<AudioSource> ();
			audio.clip = movie.audioClip;
			movie.Play ();
			audio.Play ();

		}
		
		// Update is called once per frame
		void Update () {
			timeSinceStart += Time.deltaTime;

			if (timeSinceStart >= movie.duration) {
				GameController.cutsceneDone = true;
			}
		}
	}
}