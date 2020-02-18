using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballReset : MonoBehaviour {
	
	bool isActive;
	AudioSource audioSource;
	Rigidbody rigidBody;
//	Renderer ballRenderer;
	//public Material activeMaterial;
	//public Material inactiveMaterial;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	//public TheGame _theGame;


	void Start () {
		initialPosition = transform.position;
		initialRotation = transform.rotation;


		audioSource = GetComponent<AudioSource> ();
	//	ballRenderer = GetComponent<Renderer> ();
		rigidBody = GetComponent<Rigidbody> ();

	}

	public void OnCollisionEnter (Collision ent)
	{
		if (ent.gameObject.CompareTag("Ground"))
			
		{
			PlayAudio ();
			//CheckActive ();
			ResetBall ();

		}
	}

//	public void CheckActive ()
//	{
//		if (!isActive)
//		{
//			ballRenderer.material = activeMaterial;
//		}
//		else
//		{
//			ballRenderer.material = inactiveMaterial;
//		}
//	}


	void PlayAudio () {
		if (!audioSource.isPlaying) {
			audioSource.Play ();

		}
	}


	IEnumerator Reset ()
	{
		yield return new WaitForSeconds (1);

			transform.position = initialPosition;
			transform.rotation = initialRotation;
			//ballRenderer.material = inactiveMaterial;

	//	_theGame.ResetStars ();

	}

		public void ResetBall ()
	{
		StartCoroutine (Reset ());

		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.velocity = Vector3.zero;
		rigidBody.isKinematic = true;

	}

}
