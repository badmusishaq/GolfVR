using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClub : MonoBehaviour {

	public float playForce = 10;
	AudioSource audiosource;


	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		Rigidbody rigidbody = col.gameObject.GetComponent<Rigidbody> ();
		if (col.gameObject.CompareTag ("Ball"))
		{
			rigidbody.AddForce (Vector3 .forward * playForce, ForceMode.Acceleration);
			audiosource.Play ();
		}
	}
}
