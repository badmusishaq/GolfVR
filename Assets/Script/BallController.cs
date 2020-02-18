using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public int numberOfStrokes = 0;
	public Text golfScore;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame


	void OnCollisionEnter (Collision ball)
	{
		//Rigidbody rb = ball.gameObject.GetComponent<Rigidbody> ();
		AudioSource audio = ball.gameObject.GetComponent<AudioSource> ();
		if (ball.gameObject.CompareTag ("GolfClub"))
		{
			audio.Play ();
			numberOfStrokes++;
			golfScore.text = "Par Score " + numberOfStrokes.ToString();
			//rb.AddForce (transform.forward * 50, ForceMode.Acceleration);
//
//			if (rb.velocity.magnitude < 0.001f)
//			{
//				Debug.Log ("It is above");
//				rb.velocity *= 0.9f; //Vector3.zero;
//				rb.angularVelocity = Vector3.zero;
//				rb.angularDrag = 0f;
//				rb.drag = 0f;
//				rb.mass += maxWeight;
//			}
		}
	}
}
