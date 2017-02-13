using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    int playerHealth;
	Vector3 movement;
	public Rigidbody playerRigidbody;
	public float playerSpeed = 5f;


	// Use this for initialization
	void Awake () {
		playerRigidbody = GetComponent<Rigidbody> ();
		playerHealth = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

	    movePlayer(h, v);

	}

    void movePlayer(float h, float v)
    {
		movement.Set (h, 0f, v);

		movement = movement.normalized * playerSpeed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
    }





}
