using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	public GameObject pickup;

	private int count;
	//Hello

	private Rigidbody rb;
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetText ();
		winText.text = "";
	}
	void FixedUpdate()
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, 0.0f, moveVer);
		rb.AddForce (movement * speed);


	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if(other.gameObject.CompareTag("Pickups")) {
			other.gameObject.SetActive (false);
			count++;
			SetText ();
		} 


	}

	void SetText () {
		countText.text = "Count : " + count.ToString ();
		if (count >= 12) {
			winText.text = "You are win";
		}
	}
}
