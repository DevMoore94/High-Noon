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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move(h, v);

	}

    void move(float h, float v)
    {
		movement.Set (h, 0f, v);

		movement = movement.normalized * playerSpeed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
    }
}
